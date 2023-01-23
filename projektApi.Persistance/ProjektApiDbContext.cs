using Microsoft.EntityFrameworkCore;
using projektApi.Application.Common.Interfaces;
using projektApi.Domain.Common;
using projektApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Persistance
{
    public class ProjektApiDbContext : DbContext, IProjektApiDbContext
    {

        public ProjektApiDbContext(DbContextOptions<ProjektApiDbContext> options) : base(options)
        {
        }

        #region DbSety
        public DbSet<Pies> Psy { get; set; }
        public DbSet<Kontrahent> Kontrahenci { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Wizyta> Wizyty { get; set; }
        #endregion DbSety

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kontrahent>().HasData(
               new Kontrahent()
               {
                   Id = 1,
                   StatusId = 1,
                   Nazwa_firmy = "Top Dogs",
                   Created = DateTime.Now,
                   CreatedBy = "Dawid"
               });

            //tu zobaczyć, kurs api - moduł 5 lekcja 4 - Context, to ma byc value object
            modelBuilder.Entity<Klient>().OwnsOne(p => p.KlientName); //ValeObject
            modelBuilder.Entity<Klient>(k =>
            {
                k.HasData(new Klient()
                {
                    Id = 1,
                    StatusId = 1,
                    Phone_number = "+48 606327833",
                    Created = DateTime.Now,
                    CreatedBy = "Dawid",
                    KontrahentId = 1
                });
                k.OwnsOne(k => k.KlientName).HasData(new { KlientId = 1, Name = "Andrzej", Surname = "Trycz" }); //tu wazny jest poprawna nazwa pola bo nie sprawdza
            }
                );
            modelBuilder.Entity<Pies>().HasData(
               new Pies() { Id = 1, KontrahentId = 1, KlientId = 1, Name = "Jackie" },
               new Pies() { Id = 2, KontrahentId = 1, KlientId = 1, Name = "Fifi" }
               );
            modelBuilder.Entity<Wizyta>().HasData(
                new Wizyta()
                {
                    Id = 1,
                    Data_wizyty = DateTime.Now,
                    Godzina_wizyty = DateTime.Now,
                    Kwota = 350,
                    Opis = "Strzyżenie",
                    PiesId = 1
                });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = string.Empty;
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.StatusId = 1;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.Modified = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.Modified = DateTime.Now;
                        entry.Entity.Inactivated = DateTime.Now;
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
