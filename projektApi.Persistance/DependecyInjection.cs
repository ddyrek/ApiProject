using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using projektApi.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Persistance
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjektApiDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("projektApiDatabase")));
    //.AddRoles<IdentityRole>()
    //.AddEntityFrameworkStores<ProjektApiDbContext>();
            services.AddScoped<IProjektApiDbContext, ProjektApiDbContext>();
            return services;
        }
    }
}
