using Groomer.Shared.Visits.Commands;
using MediatR;
using projektApi.Application.Common.Interfaces;
using projektApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Wizyty.Commands.AddVisitCommand
{
    public class AddVisitCommand : IRequest<int>
    {
        public AddVisitVM Visit { get; set; }
    }

    public class AddVisitCommandHandler : IRequestHandler<AddVisitCommand, int>
    {
        private readonly IProjektApiDbContext context;

        public AddVisitCommandHandler(IProjektApiDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(AddVisitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var visit = new Wizyta()
                {
                    Opis = request.Visit.Opis,
                    GodzinaWizyty = request.Visit.GodzinaWizyty,
                    DataWizyty = request.Visit.DataWizyty,
                    Kwota = request.Visit.Kwota,
                    PiesId = request.Visit.PiesId,
                };
                context.Wizyty.Add(visit);
                await context.SaveChangesAsync(cancellationToken);
                return visit.Id;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
