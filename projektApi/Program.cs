using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using projektApi;
using projektApi.Application;
using projektApi.Application.Common.Interfaces;
using projektApi.Infrastructure;
using projektApi.Infrastructure.Identity;
using projektApi.Persistance;
using projektApi.Persistance.Migrations;
using projektApi.Service;
using Serilog;
using System.Reflection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

//Serilog
try
{
    Log.Information("Application starting up");
    //CreateWebHostBuilder(args).UseSerilog().Build().Run();

}
catch (Exception ex)
{

    Log.Fatal(ex, "Unable to run application");
}
finally
{
    Log.CloseAndFlush();
}
builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));

// Add services to the container.
//Mozemy stworzyæ kilka policy, osobne dla frontendu pod web, osobno pod urz¹dzenia mobilne, osobno pod desktopy lub niektóre wspólne endpointy
builder.Services.AddCors(options => 
options.AddPolicy(name: "MyAllowSpecificOigins",
builder =>
{
     //builder.AllowAnyOrigin(); //to ustawienia pozwala po³aczyæ sie z ka¿dym origins (czyli ka¿da aplikacja kliencka sie po³¹czy siê z tym Api - przydatne gdy tworzymy publiczne API)
                               //builder.WithOrigins("https://localhost:5001"); //tylko ten origin czyli po³aczenie z API,
    builder.WithOrigins("https://localhost:7088").AllowAnyHeader().AllowAnyMethod();                                               //tylko dla aplikacji klienckiej pod tym linkiem
                                                    //("https://localhost:5001", https://kolejny origin) po przecinku te¿ zadzia³a dla tej polityki  CORS
}));

#region Webhost configuration
builder.WebHost.ConfigureAppConfiguration((hostingContext, config) =>
{

    var env = hostingContext.HostingEnvironment;

    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.Local.json", optional: true, reloadOnChange: true);

    if (env.IsDevelopment())
    {
        var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
        config.AddUserSecrets(appAssembly, optional: true);
    }

    config.AddEnvironmentVariables();

    if (args != null)
    {
        config.AddCommandLine(args);
    }
});

#endregion

if (builder.Environment.IsEnvironment("Test"))
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("projektApiDatabase")));
    builder.Services.AddDefaultIdentity<ApplicationUser>().AddEntityFrameworkStores<ApplicationDbContext>();
    builder.Services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
            {
                options.ApiResources.Add(new Duende.IdentityServer.Models.ApiResource("api1"));
                options.ApiScopes.Add(new Duende.IdentityServer.Models.ApiScope("api1"));
                options.Clients.Add(new Duende.IdentityServer.Models.Client
                {
                    ClientId = "client1",
                    AllowedGrantTypes = { GrantType.ResourceOwnerPassword },
                    ClientSecrets = { new Duende.IdentityServer.Models.Secret("secret".Sha256()) },
                    AllowedScopes = { "openid", "profile", "projektApiAPI", "api1" }
                });
            }).AddTestUsers(new List<TestUser>
            {
                        new TestUser
                        {
                            SubjectId = "4B434A88-212D-4A4D-A17C-F35102D73CBB",
                            Username = "alice",
                            Password = "Pass123$",
                            Claims = new List<Claim>
                            {
                                new Claim(JwtClaimTypes.Email, "alice@user.com"),
                                new Claim(ClaimTypes.Name, "alice")
                            }
                        }
            });
    builder.Services.AddAuthentication("Bearer").AddIdentityServerJwt();
}
else
{
    builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5001";
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("ApiScope", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("scope", "api1");
        });
    });
};

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.TryAddScoped(typeof(ICurrentUserService), typeof(CurrentUserService));

    

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();  to dodane dla opisu mojego Api


builder.Services.AddApplication();
builder.Services.AddPersistance(builder.Configuration); //dodano te¿ referencjê do projektu
builder.Services.AddInfrastructure(builder.Configuration);

#region serilog - kod ze strony www.serilog
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
#endregion

#region Serilog (dodane na podstawie projektu blazor SocialMediaPlaner.server)
//dodne do serilog intuicyjnie
//builder.Logging.ClearProviders();

//var logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

//builder.Logging.AddSerilog(logger);
#endregion 

builder.Services.AddSwaggerGen(options =>
{
#region z kursu
    options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,

        Flows = new OpenApiOAuthFlows()
        {

            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri("https://localhost:5001/connect/authorize"),
                TokenUrl = new Uri("https://localhost:5001/connect/token"),
                Scopes = new Dictionary<string, string>
                {
                    {"api1", "Demo - full access" },
                    {"user", "User info" },
                    {"openid", "openid info" }
                }
            }
        }
    });
    options.OperationFilter<AuthorizeCheckOperationFilter>();
#endregion

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Dawid Dyrek",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

//Ustawinie Swagger dostepnego tylko dla srodowiska testowego, jesli ma byc dostepny ogólnie w ka¿dym srdowsku, pomijamy if, zostawiamy zawrtoœæ if
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    //z kursu
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjektApi v1");
        options.OAuthClientId("swagger");
        options.OAuthClientSecret("secret"); //opcja
        options.OAuth2RedirectUrl("https://localhost:7233/swagger/oauth2-redirect.html");
        options.OAuthUsePkce();
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//use Cors musi byæ zawrte zawsze przezd UseAuthorization
app.UseRouting();

app.UseCors("MyAllowSpecificOigins");

app.UseAuthentication();
//dodane przy testach integracyjnych
if (builder.Environment.IsEnvironment("Test"))
{
    app.UseIdentityServer();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

//do³o¿ono by klasa program mog³a byæ widoczna w projekcie testów integracyjnych
public partial class Program { } 
