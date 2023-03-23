using Application.UnitTests.Common;
using AutoMapper;
using projektApi.Application.Kontrahenci.Queris.GetKontrahenci;
using projektApi.Application.Koontrahenci.Queris.GetKontrahenci;
using projektApi.Persistance;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Kontrahent.Queries.GetKontrahenci
{
    [Collection("QueryCollection")]
    public class GetKontrahenciQueryHandlerTests
    {
        private readonly ProjektApiDbContext _context;
        private readonly IMapper _mapper;

        public GetKontrahenciQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetKontrahenci()
        {
            var handler = new GetKontrahenciQueryHandler(_context, _mapper);

            var result = await handler.Handle(new GetKontrahenciQuery(), CancellationToken.None);
            result.ShouldBeOfType<KontrahenciVm>();
            result.Kontrahenci.Count.ShouldBe(3); //wiemy że ilość Kontrahentów powinna wynosić 2 (na podstawie Sedd + DbContextFactory)
        }
    }
}
