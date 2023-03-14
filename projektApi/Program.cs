using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using projektApi.Application;
using projektApi.Application.Common.Interfaces;
using projektApi.Infrastructure;
using projektApi.Persistance;
using projektApi.Persistance.Migrations;
using projektApi.Service;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Mozemy stworzyæ kilka policy, osobne dla frontendu pod web, osobno pod urz¹dzenia mobilne, osobno pod desktopy lub niektóre wspólne endpointy
builder.Services.AddCors(options => 
options.AddPolicy(name: "MyAllowSpecificOigins",
builder =>
{
    // builder.AllowAnyOrigin(); //to ustawienia pozwala po³aczyæ sie z ka¿dym origins (czyli ka¿da aplikacja kliencka sie po³¹czy siê z tym Api - przydatne gdy tworzymy publiczne API)
    builder.WithOrigins("https://localhost:5001"); //tylko ten origin czyli po³aczenie z API,
                                                    //tylko dla aplikacji klienckiej pod tym linkiem
                                                    //("https://localhost:5001", https://kolejny origin) po przecinku te¿ zadzia³a dla tej polityki CORS
}));

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.TryAddScoped(typeof(ICurentUserService), typeof(CurentUserService));
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
    //options.OperationFilter<AuthorizeCheckOperationFilter>();
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

//use Cors musi byæ zawrte zawsze przezd UseAuthorization
app.UseRouting();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
