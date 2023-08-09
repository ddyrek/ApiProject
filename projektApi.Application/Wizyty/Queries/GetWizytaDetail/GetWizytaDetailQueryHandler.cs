using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using projektApi.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Wizyty.Queries.GetWizytaDetail
{
    public class GetWizytaDetailQueryHandler : IRequestHandler<GetWizytaDetailQuery, WizytaDetailVm>
    {
        private readonly IProjektApiDbContext _context;
        private IMapper _mapper; //dodane przy automaperze
        public GetWizytaDetailQueryHandler(IProjektApiDbContext projectApiDbContext, IMapper mapper)
        {
            _context = projectApiDbContext;
            _mapper = mapper;
        }
        public async Task<WizytaDetailVm> Handle(GetWizytaDetailQuery request, CancellationToken cancellationToken)
        {
            var wizyta = await _context.Wizyty.Include(p => p.Pies).Where(p => p.Id == request.WizytaId).FirstOrDefaultAsync(cancellationToken);

            //opcja zamiast automappera(przed dodaniem automappera)
            //var klientVm = new KlientDetailVm()
            //{
            //    //zmapowanie
            //    FullName = klient.KlientName.ToString(),
            //    LastPiesName = klient.Psy.OrderByDescending(p => p.Name).FirstOrDefault().Name
            //};

            var wizytaVm = _mapper.Map<WizytaDetailVm>(wizyta); //pokazujemy AM co chcemy zmapować i na jaki element

            return wizytaVm;
        }
    }
}
