using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using projektApi.Application.Common.Interfaces;
using projektApi.Application.Kontrahenci.Queris.GetKontrahenci;
using projektApi.Application.Koontrahenci.Queris.GetKontrahenci;
using projektApi.Domain.Excpetions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Psy.Queries.GetPsy
{
    public class GetPsyQueryHandler : IRequestHandler<GetPsyQuery, PsyVm>
    {
        private readonly IProjektApiDbContext _context;
        private IMapper _mapper;
        public GetPsyQueryHandler(IProjektApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PsyVm> Handle(GetPsyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var psy = await _context.Psy.AsNoTracking().ProjectTo<PiesDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
                if (psy == null)
                {
                    throw new ThisObjectNotExistInDbException("Psy");
                }

                return new PsyVm() { Psy = psy };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
