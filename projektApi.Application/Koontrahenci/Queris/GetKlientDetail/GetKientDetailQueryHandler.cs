using MediatR;
using Microsoft.EntityFrameworkCore;
using projektApi.Application.Common.Interfaces;
using projektApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Koontrahenci.Queris.GetKlientDetail
{
    public class GetKientDetailQueryHandler : IRequestHandler<GetKlientDetailQuery, KlientDetailVm>
    {
        private readonly IProjektApiDbContext _context;
        public GetKientDetailQueryHandler(IProjektApiDbContext projectApiDbContext)
        {
            _context = projectApiDbContext;
        }
        public async Task<KlientDetailVm> Handle(GetKlientDetailQuery request, CancellationToken cancellationToken)
        {
            var klient = await _context.Klienci.Where(p => p.Id == request.KlientId).FirstOrDefaultAsync(cancellationToken);
            var klientVm = new KlientDetailVm()
            {
                //zmapowanie
                FullName = klient.KlientName.ToString(),
                LastPiesName = klient.Psy.OrderByDescending(p => p.Name).FirstOrDefault().Name
            };

            return klientVm;
        }
    }
}
