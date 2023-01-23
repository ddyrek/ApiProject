using Microsoft.EntityFrameworkCore;
using projektApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Persistance
{
    public static class Seed
    {
        public  static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kontrahent>().HasData(
               new Kontrahent()
               {
                   Id = 1,
                   StatusId = 1,
                   NazwaFirmy = "Top Dogs",
                   Created = DateTime.Now,
                   CreatedBy = "Dawid"
               });

            modelBuilder.Entity<Klient>(k =>
            {
                k.HasData(new Klient()
                {
                    Id = 1,
                    StatusId = 1,
                    PhoneNumber = "+48 606327833",
                    Created = DateTime.Now,
                    CreatedBy = "Dawid",
                    KontrahentId = 1
                });
                k.OwnsOne(k => k.KlientName).HasData(new { KlientId = 1, Name = "Andrzej", Surname = "Trycz" }); //tu wazny jest poprawna nazwa pola bo nie sprawdza
            }
                );
            modelBuilder.Entity<Pies>().HasData(
               new Pies() { Id = 1, KontrahentId = 1, KlientId = 1, Name = "Jackie", Race = "BORDER COLLIE" },
               new Pies() { Id = 2, KontrahentId = 1, KlientId = 1, Name = "Fifi", Race = "BORDER TERRIER" }
               );
            modelBuilder.Entity<Wizyta>().HasData(
                new Wizyta()
                {
                    Id = 1,
                    DataWizyty = DateTime.Now,
                    GodzinaWizyty = DateTime.Now,
                    Kwota = 350,
                    Opis = "Strzyżenie",
                    PiesId = 1
                });
        }
    }
}
