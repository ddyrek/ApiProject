using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using projektApi.Application.Common.Interfaces;
using projektApi.Application.Klienci.Queris.GetKlientDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Koontrahenci.Queris.GetKontrahentDetail
{
    public class GetKontrahentDetailQueryHandler : IRequestHandler<GetKontrahentDetailQuery, KontrahentDetailVm>
    {
        private readonly IProjektApiDbContext _context;
        private IMapper _mapper; //dodane przy automaperze
        public GetKontrahentDetailQueryHandler(IProjektApiDbContext projectApiDbContext, IMapper mapper)
        {
            _context = projectApiDbContext;
            _mapper = mapper;
        }
        public async Task<KontrahentDetailVm> Handle(GetKontrahentDetailQuery request, CancellationToken cancellationToken)
        {
            var kontrahent = await _context.Kontrahenci.Include(p => p.Psy).Where(p => p.Id == request.KontrahentId).FirstOrDefaultAsync(cancellationToken);

            //opcja zamiast automappera(przed dodaniem automappera)
            //var kontrahentVm = new KontrahentDetailVm()
            //{
            //    //zmapowanie
            //    FullName = kontrahent.KontrahentName.ToString(),
            //    LastPiesName = kontrahent.Psy.OrderByDescending(p => p.Name).FirstOrDefault().Name
            //};

            var kontrahentVm = _mapper.Map<KontrahentDetailVm>(kontrahent); //pokazujemy AM co chcemy zmapować i na jaki element

            return kontrahentVm;
        }
    }
}
