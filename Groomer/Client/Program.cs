using Groomer.Client;
using Groomer.Client.Brokers.API;
using Groomer.Client.Configurations;
using Groomer.Client.Service;
using Groomer.Client.Service.Customers;
using Groomer.Client.Service.Dogs;
using Groomer.Client.Service.Visits;
using Majorsoft.Blazor.Components.CssEvents;
using Majorsoft.Blazor.Components.Notifications;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#wrapper");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("api")
    .AddHttpMessageHandler(sp =>
    {
        var handler = sp.GetService<AuthorizationMessageHandler>()
            .ConfigureHandler(
                authorizedUrls: new[] { "https://localhost:7233/" },
                scopes: new[] { "api1" });
        return handler;
    });

builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("api"));
var url = builder.Configuration.Get<Configuration>().ApiConfiguration.Url;
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(url) });
builder.Services.AddScoped<IApiBroker, ApiBroker>();
//rejestracja do kontenera IoC/DI VisitsService je¿eli nasze Api ³aczymy do servisu
builder.Services.AddScoped<IVisitsService, VisitsService>();
//builder.Services.AddScoped<CustomersService>(); //opcja gdy pusy interfejs lub go brak
builder.Services.AddScoped<ICustomersService, CustomersService>();
builder.Services.AddScoped<IDogsService, DogsService>();

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("oidc", options.ProviderOptions);
});
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddCssEvents(); //powidomienia pushNotificatons
builder.Services.AddNotifications(); //powidomienia pushNotificatons

//logger
//builder.Configuration.AddConfiguration(builder.Configuration.GetSection("Logging")); //add section from appsetings
//loger level on Environment
if (builder.HostEnvironment.IsDevelopment())
{
    builder.Logging.SetMinimumLevel(LogLevel.Information);
}
else if (builder.HostEnvironment.IsStaging())
{
    builder.Logging.SetMinimumLevel(LogLevel.Warning);
}
else if (builder.HostEnvironment.IsProduction())
{
    builder.Logging.SetMinimumLevel(LogLevel.Error);
}

await builder.Build().RunAsync();
