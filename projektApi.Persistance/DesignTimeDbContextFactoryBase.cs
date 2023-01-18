using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design; //paczka żeby context był realizowany w czasie DesignTime a nie RunTime
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Persistance
{
    public abstract class DesignTimeDbContextFactoryBase<TContext> :
            IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        private const string ConnectionStringName = "projektApiDatabase";
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        //metoda CreateDbContext zostanie wywołana w momencie migracji
        //bedzie na szukała głownego folderu z projektem naszego API, bo tam AppSetings i Startup bo tam znaduje sie contener IoC
        //Ioc- konfiguracja naszego DeppendencyInnjection
        public TContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}ProjektApi", Path.DirectorySeparatorChar);
            return Create(basePath, Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
        }

        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        //metoda Create zwraca appsetings
        private TContext Create(string basePath, string environmentName)
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Local.json", optional: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true) //środowisko na którym sie znajdujemy
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString(ConnectionStringName);

            return Create(connectionString);
        }

        private TContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));
            }

            Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();

            optionsBuilder.UseSqlServer(connectionString); //tu ustawiamy że połcznie z SqlServer bazą danych, jeśli inna baza danych to tu zminiamy + paczka w using

            return CreateNewInstance(optionsBuilder.Options);
        }
    }
}