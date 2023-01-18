using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using projektApi.Application;
using projektApi.Persistance;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Mozemy stworzyæ kilka policy, osobne dla frontendu pod web, osobno pod urz¹dzenia mobilne, osobno pod desktopy lub niektóre wspólne endpointy
builder.Services.AddCors(options => 
options.AddPolicy(name: "MyAllowSpecificOigins",
builder =>
{
    // builder.AllowAnyOrigin(); //to ustawienia pozwala po³aczyæ sie z ka¿dym origins (czyli ka¿da aplikacja kliencka sie po³¹czy siê z tym Api - przydatne gdy tworzymy publiczne API)
    builder.WithOrigins("https://localhost:44359"); //tylko ten origin czyli po³aczenie z API,
                                                    //tylko dla aplikacji klienckiej pod tym linkiem
                                                    //("https://localhost:44359", https://kolejny origin) po przecinku te¿ zadzia³a dla tej polityki CORS
}));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();  to dodane dla opisu mojego Api


builder.Services.AddApplication();
builder.Services.AddPersistance(builder.Configuration); //dodano te¿ referencjê do projektu

builder.Services.AddSwaggerGen(options =>
{
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
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//use Cors musi byæ zawrte zawsze przezd UseAuthorization

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
