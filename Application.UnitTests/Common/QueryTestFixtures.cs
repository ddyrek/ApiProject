using AutoMapper;
using projektApi.Application.Common.Mappings;
using projektApi.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Common
{
    public class QueryTestFixtures : IDisposable
    {
        public ProjektApiDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }
        public QueryTestFixtures()
        {
            Context = ProjektApiDbContextFactory.Create().Object;

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            ProjektApiDbContextFactory.Destroy(Context);
        }
    }

    //w XUnit, zestaw danych króry bedzie przekazywany do metody testowej, 
    // dzięki utworzeniu kolekcji zawpewnimy że testy nie zostana wykonane współbierznie
    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixtures> { }
}
