using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using projektApi.Application.Common.Interfaces;
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
            services.AddTransient<IDateTime, DateTimeService>();
            return services;
        }
    }
}
