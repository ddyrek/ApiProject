using Microsoft.EntityFrameworkCore;
using Moq;
using projektApi.Application.Common.Interfaces;
using projektApi.Domain.Entities;
using projektApi.Persistance;
using projektApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Common
{
    public static class ProjektApiDbContextFactory
    {
        public static Mock<ProjektApiDbContext> Create()
        {
            var dateTime = new DateTime(2000, 1, 1);
            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now).Returns(dateTime);

            var currentUserMock = new Mock<CurrentUserService>();
            currentUserMock.Setup(m => m.Email).Returns("user@user.pl");
            currentUserMock.Setup(m => m.IsAuthenticated).Returns(true);

            var options = new DbContextOptionsBuilder<ProjektApiDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var mock = new Mock<ProjektApiDbContext>(options, dateTimeMock.Object, currentUserMock.Object) { CallBase = true };

            var context = mock.Object;

            //sprawdzamy czy baza danych została utworzona (InMenory)
            context.Database.EnsureCreated();


            //Id musi być kolejne jak w seed data
            var kontrahent = new projektApi.Domain.Entities.Kontrahent() { Id = 3, StatusId = 1,  NazwaFirmy = "FirmaTest" };
            context.Kontrahenci.Add(kontrahent); 

            var klient = new Klient() { Id = 2, StatusId = 1, KlientName = new projektApi.Domain.ValueObjects.PersonName() { Name = "Dawid", Surname = "Dyrek" },
            PhoneNumber = "+48 606327833",KontrahentId = 3};
            context.Klienci.Add(klient);

            var pies = new Pies() { KlientId = 2, KontrahentId = 3, Name = "Astor", Race = "BORDER COLLIE", Id = 3 };
            context.Psy.Add(pies);

            var wizyta = new Wizyta() { PiesId = 3, Id = 2, DataWizyty = new DateTime(2012, 1, 1), GodzinaWizyty = new DateTime(2012, 1, 1, 13, 23, 34), Kwota = 230, Opis = "Strzyżenie, pielęgnacja" };
            context.Wizyty.Add(wizyta);
            context.SaveChanges();

            return mock;
        }

        public static void Destroy(ProjektApiDbContext context)
        {
            context.Database.EnsureDeleted(); //usuniecie BD InMemory
            context.Dispose(); //zwolnienie pamieci
        }
    }
}
