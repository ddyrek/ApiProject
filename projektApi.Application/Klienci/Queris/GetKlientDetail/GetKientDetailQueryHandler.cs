using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using projektApi.Application.Common.Interfaces;
using projektApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Klienci.Queris.GetKlientDetail
{
    public class GetKientDetailQueryHandler : IRequestHandler<GetKlientDetailQuery, KlientDetailVm>
    {
        private readonly IProjektApiDbContext _context;
        private IMapper _mapper; //dodane przy automaperze
        public GetKientDetailQueryHandler(IProjektApiDbContext projectApiDbContext, IMapper mapper)
        {
            _context = projectApiDbContext;
            _mapper = mapper;
        }
        public async Task<KlientDetailVm> Handle(GetKlientDetailQuery request, CancellationToken cancellationToken)
        {
            var klient = await _context.Klienci.Where(p => p.Id == request.KlientId).FirstOrDefaultAsync(cancellationToken);

            //opcja zamiast automappera(przed dodaniem automappera)
            //var klientVm = new KlientDetailVm()
            //{
            //    //zmapowanie
            //    FullName = klient.KlientName.ToString(),
            //    LastPiesName = klient.Psy.OrderByDescending(p => p.Name).FirstOrDefault().Name
            //};

            var klientVm = _mapper.Map<KlientDetailVm>(klient); //pokazujemy AM co chcemy zmapować i na jaki element

            return klientVm;
        }
    }
}
