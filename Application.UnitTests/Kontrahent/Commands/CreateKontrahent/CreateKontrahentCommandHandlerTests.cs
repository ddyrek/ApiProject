using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using projektApi.Application.Kontrahenci.Commands.CreateKontrahent;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Kontrahent.Commands.CreateKontrahent
{
    public class CreateKontrahentCommandHandlerTests : CommandTestBase
    {
        private readonly CreateKontrahentCommandHandler _handler;
        public CreateKontrahentCommandHandlerTests(CommandTestFixture fixture)
            : base()
        {
            _handler = new CreateKontrahentCommandHandler(_context, fixture.Mapper);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertDirector()
        {
            var command = new CreateKontrahentCommand()
            {
                NazwaFirmy = "Animal Sp. z o.o.",
                NumerBudynku = "23",
                NumerLokalu = "11",
                Ulica = "Limanowskiego",
                Nip = "2335434576"
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var dir = await _context.Kontrahenci.FirstAsync(x => x.Id == result, CancellationToken.None);

            dir.ShouldNotBeNull();

        }
    }
}
