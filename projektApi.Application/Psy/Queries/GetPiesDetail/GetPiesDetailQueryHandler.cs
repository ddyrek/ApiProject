using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using projektApi.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Psy.Queries.GetPiesDetail
{
    public class GetPiesDetailQueryHandler : IRequestHandler<GetPiesDetailQuery, PiesDetailVm>
    {
        private readonly IProjektApiDbContext _context;
        private IMapper _mapper;
        public GetPiesDetailQueryHandler(IProjektApiDbContext projectApiDbContext, IMapper mapper)
        {
            _context = projectApiDbContext;
            _mapper = mapper;
        }
        public async Task<PiesDetailVm> Handle(GetPiesDetailQuery request, CancellationToken cancellationToken)
        {
            var pies = await _context.Psy.Include(p => p.Klient).Where(p => p.Id == request.PiesId).FirstOrDefaultAsync(cancellationToken);

            //opcja zamiast automappera(przed dodaniem automappera)
            //var klientVm = new KlientDetailVm()
            //{
            //    //zmapowanie
            //    FullName = klient.KlientName.ToString(),
            //    LastPiesName = klient.Psy.OrderByDescending(p => p.Name).FirstOrDefault().Name
            //};

            var piesVm = _mapper.Map<PiesDetailVm>(pies); //pokazujemy AM co chcemy zmapować i na jaki element

            return piesVm;
        }
    }
}
