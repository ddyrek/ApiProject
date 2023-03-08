using Duende.IdentityServer;
using Duende.IdentityServer.AspNetIdentity;
using Duende.IdentityServer.Services;
using IdentityServer.Data;
using IdentityServer.Models;
using IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace IdentityServer;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        builder.Services.AddTransient<IProfileService,ProfileService>();//dodane z kursu

        builder.Services
            .AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/
                options.EmitStaticAudienceClaim = true;
            })
            .AddInMemoryIdentityResources(Config.IdentityResources)
            .AddInMemoryApiScopes(Config.ApiScopes)
            .AddInMemoryClients(Config.Clients)
            .AddJwtBearerClientAuthentication() //do³o¿one z kursu
            .AddProfileService<ProfileService>()//do³o¿one z kursu
            .AddAspNetIdentity<ApplicationUser>();
        
        builder.Services.AddAuthentication()
            .AddGoogle(options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                // register your IdentityServer with Google at https://console.developers.google.com
                // enable the Google+ API
                // set the redirect URI to https://localhost:5001/signin-google
                options.ClientId = "copy client ID from Google here";
                options.ClientSecret = "copy client secret from Google here";
            })
            .AddLocalApi();//dodane na podstawie podpowiedzi VAzaras - notatki

        //dodane na podstawie podpowiedzi VAzaras - notatki
        // Dodanie CORS dla aplikacj które bêd¹ z korzystaæ z naszego API polecam równie¿ 
        //dodaæ headery i methody
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CORS", policy => policy.WithOrigins(
                "https://localhost:5001",
                "https://localhost:6001",
                "https://localhost:7001"
                )
            .AllowAnyHeader() //umo¿³iwia wszystkim Headearom
            .AllowAnyMethod());
        });

        //dodane na podstawie podpowiedzi VAzaras - notatki
        // Dodanie AddAutorization (z poradnika Dudende)
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy(IdentityServerConstants.LocalApi.PolicyName, policy =>
            {
                policy.AddAuthenticationSchemes(IdentityServerConstants.LocalApi.AuthenticationScheme);
                policy.RequireAuthenticatedUser();
                //custom requirements
            });
        });

        return builder.Build();
    }
    
    public static WebApplication ConfigurePipeline(this WebApplication app)
    { 
        app.UseSerilogRequestLogging();
    
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // //dodane na podstawie podpowiedzi VAzaras - notatki
        // Dodanie w odpowiedniej kolejnoœci middleware (kolejnoœæ jest bardzo wa¿na…)
        app.UseStaticFiles();
        app.UseRouting();
        app.UseIdentityServer();

        app.UseCors("CORS");//

        app.UseAuthentication();//
        app.UseAuthorization();

        app.MapControllers();//
        app.MapRazorPages()
            .RequireAuthorization();

        return app;
    }
}