using Microsoft.EntityFrameworkCore;
using projektApi.Application.Common.Interfaces;
using projektApi.Domain.Common;
using projektApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Persistance
{
    public class ProjektApiDbContext : DbContext, IProjektApiDbContext
    {
        private readonly IDateTime _dateTime;
        public ProjektApiDbContext(DbContextOptions<ProjektApiDbContext> options) : base(options)
        {
        }

        public ProjektApiDbContext(DbContextOptions<ProjektApiDbContext> options, IDateTime dateTime) : base(options)
        {
            _dateTime = dateTime;
        }

        #region DbSety
        public DbSet<Pies> Psy { get; set; }
        public DbSet<Kontrahent> Kontrahenci { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Wizyta> Wizyty { get; set; }
        #endregion DbSety

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//wskazanie na konfigurację w Configuration Folderze dla FluentApi
            modelBuilder.SeedData();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = string.Empty;
                        entry.Entity.Created = _dateTime.Now; // entry.Entity.Created = DateTime.Now;// pozamieniane dla jednego czasu
                        entry.Entity.StatusId = 1;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.Modified = _dateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.Modified = _dateTime.Now;
                        entry.Entity.Inactivated = _dateTime.Now;
                        entry.Entity.InactivatedBy = string.Empty;
                        entry.Entity.StatusId = 0;
                        entry.State = EntityState.Modified;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
