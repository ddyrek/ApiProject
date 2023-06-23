using Newtonsoft.Json;
using projektApi.Domain.Entities;
using projektApi.Persistance;

namespace WebApi.IntegrationTests.Common
{
    public class Utilities
    {
        public static async Task<T> GetResponseContent<T>(HttpResponseMessage response)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(stringResponse);

            return result;
        }
        public static void InitilizeDbForTests(ProjektApiDbContext context)
        {
            var kontrahent = new projektApi.Domain.Entities.Kontrahent() { /*Id = 3, */StatusId = 1, NazwaFirmy = "FirmaTest", CreatedBy = "Roby" };
            context.Kontrahenci.Add(kontrahent);

            var klient = new Klient()
            {
                /*Id = 2,*/
                StatusId = 1,
                KlientName = new projektApi.Domain.ValueObjects.PersonName() { Name = "Dawid", Surname = "Dyrek" },
                PhoneNumber = "+48 606327833",
                KontrahentId = 3,
                CreatedBy = "Wily"
            };
            context.Klienci.Add(klient);

            var pies = new Pies() { KlientId = 2, KontrahentId = 3, Name = "Astor", Race = "BORDER COLLIE", /*Id = 3*/ };
            context.Psy.Add(pies);

            var wizyta = new Wizyta() { PiesId = 3, /*Id = 2,*/ DataWizyty = new DateTime(2012, 1, 1), GodzinaWizyty = new DateTime(2012, 1, 1, 13, 23, 34), Kwota = 230, Opis = "Strzyżenie, pielęgnacja" };
            context.Wizyty.Add(wizyta);
            context.SaveChanges();
        }
    }
}
