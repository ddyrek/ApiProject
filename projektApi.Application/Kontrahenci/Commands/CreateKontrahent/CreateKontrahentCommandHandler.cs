using MediatR;
using projektApi.Application.Common.Interfaces;
using projektApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Kontrahenci.Commands.CreateKontrahent
{
    public class CreateKontrahentCommandHandler : IRequestHandler<CreateKontrahentCommand, int>
    {
        private readonly IProjektApiDbContext _context;
        public CreateKontrahentCommandHandler(IProjektApiDbContext projectApiDbContext)
        {
            _context = projectApiDbContext;
        }
        public async Task<int> Handle(CreateKontrahentCommand request, CancellationToken cancellationToken)
        {
            Kontrahent kontrahent = new()
            {
                //KontrahentName = new Domain.ValueObjects.PersonName() { Name = request.Name, Surname = request.Surname },
                NazwaFirmy = request.NazwaFirmy,
                Ulica = request.Ulica,
                //StatusId = 1,
                NumerBudynku = request.NumerBudynku,
                NumerLokalu = request.NumerLokalu,
                Nip = request.Nip,
                //CreatedBy = request.CreatedBy,
                //Created = DateTime.Now
            };

            _context.Kontrahenci.Add(kontrahent);

            await _context.SaveChangesAsync(cancellationToken);

            return kontrahent.Id;
        }
    }
}
