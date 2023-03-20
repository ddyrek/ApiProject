using Application.UnitTests.Common;
using AutoMapper;
using projektApi.Application.Koontrahenci.Queris.GetKontrahentDetail;
using projektApi.Persistance;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Kontrahent.Queries.GetKontrahentDetail
{
    [Collection("QueryCollection")]
    public class GetKontrahentDetailQueryHandlerTests
    {
        private readonly ProjektApiDbContext _context;
        private readonly IMapper _mapper;

        public GetKontrahentDetailQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetKontrahentDetailById()
        {
            var handler = new GetKontrahentDetailQueryHandler(_context, _mapper);
            var kontrahentId = 3; //Id jak w fabryce

            var result = await handler.Handle(new GetKontrahentDetailQuery { KontrahentId = kontrahentId }, CancellationToken.None);
            result.ShouldBeOfType<KontrahentDetailVm>();
            result.NazwaFirmy.ShouldBe("FirmaTest"); //ta sama wartość jak w fabryce
        }
    }
}
