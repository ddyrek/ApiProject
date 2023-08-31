using Groomer.Shared.Visits.Queries.AllVisitsQuery;
using MediatR;
using Microsoft.EntityFrameworkCore;
using projektApi.Application.Common.Interfaces;
using projektApi.Domain.Entities;
using projektApi.Domain.Excpetions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Wizyty.Queries.AllVisitsQuery
{
    public class AllVisitsQuery : IRequest<List<VisitForListVm>>
    {
    }

    public class AllVisitQueryHandler : IRequestHandler<AllVisitsQuery, List<VisitForListVm>>
    {
        public readonly IProjektApiDbContext _context;
        public AllVisitQueryHandler(IProjektApiDbContext context)
        {
            _context = context;
        }
        public async Task<List<VisitForListVm>> Handle(AllVisitsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var visits = await _context.Wizyty.ToListAsync();
                if (visits == null)
                {
                    throw new ThisObjectNotExistInDbException("Wizyty");
                }

                return MapVisitsToVm(visits);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private List<VisitForListVm> MapVisitsToVm(List<Wizyta> visits)
        {
            var result = new List<VisitForListVm>();
            foreach (var visit in visits)
            {
                var visitVm = new VisitForListVm()
                {
                    Id = visit.Id,
                    DataWizyty = visit.DataWizyty,
                    GodzinaWizyty = visit.GodzinaWizyty,
                    Kwota = visit.Kwota,
                    Opis = visit.Opis,
                    PiesId = visit.PiesId
                };
                result.Add(visitVm);
            }
            return result;
        }
    }
}
