using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using projektApi.Application.Common.Interfaces;
using projektApi.Domain.Excpetions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Koontrahenci.Queris.GetKontrahenci
{
    public class GetKontrahenciHandler : IRequestHandler<GetKontrahenciQuery, KontrahenciVm>
    {
        private readonly IProjektApiDbContext _context;
        private IMapper _mapper;
        public GetKontrahenciHandler(IProjektApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<KontrahenciVm> Handle(GetKontrahenciQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var kontrahenci = await _context.Kontrahenci.Where(x => x.StatusId == 1).AsNoTracking().ProjectTo<KontrahentDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
                if (kontrahenci == null)
                {
                    throw new ThisObjectNotExistInDbException("Kontrahenci");
                }

                return new KontrahenciVm() { Kontrahenci = kontrahenci };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
