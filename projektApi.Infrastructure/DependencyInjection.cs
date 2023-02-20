using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using projektApi.Application.Common.Interfaces;
using projektApi.Infrastructure.ExternalAPI.GOVPL;
using projektApi.Infrastructure.FileStore;
using projektApi.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("GovplClient", options =>
            {
                options.BaseAddress = new Uri("https://bdl.stat.gov.pl");
                options.Timeout = new TimeSpan(0, 0, 10);
                options.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }).ConfigurePrimaryHttpMessageHandler(sp => new HttpClientHandler());
  
            services.AddScoped<IGovplClient, GovplClient>();
            //wstrzykniecie services do kontenera IOC
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IFileStore, FileStore.FileStore>();
            services.AddTransient<IFileWrapper, FileWrapper>();
            services.AddTransient<IDirectoryWrapper, DirectoryWrapper>();
            return services;
        }
    }
}
