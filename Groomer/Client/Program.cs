using Groomer.Client;
using Groomer.Client.Service;
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
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("oidc", options.ProviderOptions);
});
builder.Services.AddScoped<ITestService, TestService>();

//logger
//builder.Configuration.AddConfiguration(builder.Configuration.GetSection("Logging")); //add section from appsetings
//loger level on Environment
if(builder.HostEnvironment.IsDevelopment())
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
