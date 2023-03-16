using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Mapping
{
    public class MappingTest : IClassFixture<MappingTestFixture>
    {
        private readonly IConfigurationProvider _configration;
        private readonly IMapper _mapper;

        public MappingTest(MappingTestFixture fixture)
        {
            _configration = fixture.ConfigurationProvider;
            _mapper = fixture.Mapper;
        }

        //test konfiguracji automappera, Fact oznacza test
        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configration.AssertConfigurationIsValid();
        }
    }
}
