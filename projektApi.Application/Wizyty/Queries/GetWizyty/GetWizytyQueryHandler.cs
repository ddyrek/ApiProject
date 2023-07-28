using AutoMapper;
using AutoMapper.QueryableExtensions;
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

namespace projektApi.Application.Wizyty.Queries.GetWizyty
{
    public class GetWizytyQueryHandler : IRequestHandler<GetWizytyQuery, WizytyVm>
    {
        private readonly IProjektApiDbContext _context;
        private IMapper _mapper;
        public GetWizytyQueryHandler(IProjektApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WizytyVm> Handle(GetWizytyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //var wizyty = await _context.Wizyty.Where(x => x.StatusId == 1).AsNoTracking().ProjectTo<WizytaDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
                var wizyty = await _context.Wizyty.AsNoTracking().ProjectTo<WizytaDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
                if (wizyty == null)
                {
                    throw new ThisObjectNotExistInDbException("Wizyty");
                }

                return new WizytyVm() { Wizyty = wizyty };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
