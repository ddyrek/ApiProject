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
    public class UpdateKontrahentCommandHandler : IRequestHandler<UpdateKontrahentCommand, Unit>
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
        public async Task<Unit> Handle(UpdateKontrahentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //await ValidRequest(request);
                //var kontrahent = new Kontrahent();
                //Kontrahent kontrahent = _mapper.Map<Kontrahent>(request);
                var kontrahentToUpdate = await _context.Kontrahenci
                    .Where(x => x.Id == request.KontrahentId 
                             && x.StatusId == 1)
                    .FirstOrDefaultAsync(cancellationToken);

                if (kontrahentToUpdate == null)
                {
                    throw new ObjectNotExistInDbException(request.KontrahentId, "Kontrahent");
                };

                var kontrahent = _mapper.Map<UpdateKontrahentCommand,Kontrahent>(request,kontrahentToUpdate); //zmapowanie zamiast tradycyjnego przypisania jak poniżej (musi być Id zmapowane w Command)
                //kontrahent.NazwaFirmy = request.NazwaFirmy;
                //kontrahent.Ulica = request.Ulica;
                //kontrahent.NumerBudynku = request.NumerBudynku;
                //kontrahent.NumerLokalu = request.NumerLokalu;
                //kontrahent.Nip = request.Nip;

                _context.Kontrahenci.Update(kontrahent);
                try
                {
                    await _context.SaveChangesAsync(cancellationToken);
                }
                catch (DbUpdateException)
                {
                    throw new DbUpdateException("Saving to database error!");
                }

                return Unit.Value;//true;//kontrahent.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
