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
        private readonly ICurrentUserService _userService;
        public ProjektApiDbContext(DbContextOptions<ProjektApiDbContext> options) : base(options)
        {
        }

        public ProjektApiDbContext(DbContextOptions<ProjektApiDbContext> options, IDateTime dateTime, ICurrentUserService userService) : base(options)
        {
            _dateTime = dateTime;
            _userService = userService;
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
                        entry.Entity.CreatedBy = _userService.Email; //string.Empty;
                        entry.Entity.Created = _dateTime.Now; // entry.Entity.Created = DateTime.Now;// pozamieniane dla jednego czasu
                        entry.Entity.StatusId = 1;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = _userService.Email; //string.Empty;
                        entry.Entity.Modified = _dateTime.Now; //wczesniej = DateTime.Now
                        break;
                    case EntityState.Deleted:
                        entry.Entity.ModifiedBy = _userService.Email; //string.Empty;
                        entry.Entity.Modified = _dateTime.Now; //wczesniej = DateTime.Now
                        entry.Entity.Inactivated = _dateTime.Now; //wczesniej = DateTime.Now
                        entry.Entity.InactivatedBy = _userService.Email; //string.Empty;
                        entry.Entity.StatusId = 0;
                        entry.State = EntityState.Modified;
                        break;
                    default:
                        break;
                }
            }

            foreach (var entry in ChangeTracker.Entries<ValueObject>())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
