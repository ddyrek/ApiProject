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


            //Id musi być kojejne jak w seed data
            var kontrahent = new Kontrahent() { Id = 2, StatusId = 1,  NazwaFirmy = "FirmaTest" };
            context.Kontrahenci.Add(kontrahent); 

            //var kontrahent = new projektApi.Domain.Entities.Kontrahent) { Id = 2, StatusId = 1, KontrahentName = new projektApi.Domain.ValueObjects.PersonName() { FirstName = "Dawid", LastName = "Dyrek" } };
            //context.Kontrahenci.Add(kontrahent);

            //var directorBiography = new DirectorBiography() { DirectorId = 2, Id = 2, DoB = new DateTime(1950, 1, 1), PlaceOfBirth = "Warsaw" };
            //context.DirectorBiographies.Add(directorBiography);

            //var genre = new Genre() { Id = 1, Name = "Comedy" };
            //context.Genres.Add(genre);

            //var movie = new Movie() { DirectorId = 2, Genres = new List<Genre>() { genre }, Name = "MovieName", PremiereYear = 2000, Id = 3 };

            //context.Movies.Add(movie);

            context.SaveChanges();

            return mock;
        }

        public static void Destroy(ProjektApiDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
