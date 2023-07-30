using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using projektApi.Application.Common.Interfaces;
using projektApi.Application.Klienci.Queris.GetKlienci;
using projektApi.Domain.Excpetions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Klienci.Queris.GetKlienci
{
    public class GetKlienciQueryHandler : IRequestHandler<GetKlienciQuery, KlienciVm>
    {
        private readonly IProjektApiDbContext _context;
        private IMapper _mapper;
        public GetKlienciQueryHandler(IProjektApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<KlienciVm> Handle(GetKlienciQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var klienci = await _context.Klienci.Where(x => x.StatusId == 1).AsNoTracking().ProjectTo<KlientDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
                if (klienci == null)
                {
                    throw new ThisObjectNotExistInDbException("Klienci");
                }

                return new KlienciVm() { Klienci = klienci };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
