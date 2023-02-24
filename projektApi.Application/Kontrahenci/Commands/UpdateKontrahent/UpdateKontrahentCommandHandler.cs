using AutoMapper;
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

namespace projektApi.Application.Kontrahenci.Commands.UpdateKontrahent
{
    public class UpdateKontrahentCommandHandler : IRequestHandler<UpdateKontrahentCommand, int>
    {
        private readonly IProjektApiDbContext _context;
        private IMapper _mapper;

        public UpdateKontrahentCommandHandler(
            IProjektApiDbContext projectApiDbContext,
            IMapper mapper)
        {
            _context = projectApiDbContext;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateKontrahentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //await ValidRequest(request);
                //var kontrahent = new Kontrahent();
                //Kontrahent kontrahent = _mapper.Map<Kontrahent>(request);
                var kontrahent = await _context.Kontrahenci
                    .Where(x => x.Id == request.KontrahentId && x.StatusId == 1)
                    .FirstOrDefaultAsync(cancellationToken);
                if (kontrahent == null)
                {
                    throw new ObjectNotExistInDbException(request.KontrahentId, "Kontrahent");
                };

                kontrahent.NazwaFirmy = request.NazwaFirmy;
                kontrahent.Ulica = request.Ulica;
                kontrahent.NumerBudynku = request.NumerBudynku;
                kontrahent.NumerLokalu = request.NumerLokalu;
                kontrahent.Nip = request.Nip;

                _context.Kontrahenci.Update(kontrahent);
                try
                {
                    await _context.SaveChangesAsync(cancellationToken);
                }
                catch (DbUpdateException)
                {
                    throw new DbUpdateException("Saving to database error!");
                }

                return kontrahent.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
