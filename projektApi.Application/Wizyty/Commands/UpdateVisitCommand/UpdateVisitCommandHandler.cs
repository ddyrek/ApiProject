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

namespace projektApi.Application.Wizyty.Commands.UpdateVisitCommand
{
    public class UpdateVisitCommandHandler : IRequestHandler<UpdateVisitCommand, Unit>
    {
        private readonly IProjektApiDbContext _context;
        private IMapper _mapper;

        public UpdateVisitCommandHandler(
            IProjektApiDbContext projectApiDbContext,
            IMapper mapper)
        {
            _context = projectApiDbContext;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateVisitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //await ValidRequest(request);
                //var wizyta = new Wizyta();
                //Wizyta wizyta = _mapper.Map<Wizyta>(request);
                var wizytaToUpdate = await _context.Wizyty
                    .Where(x => x.Id == request.WizytaId
                             /*&& x.StatusId == 1*/)
                    .FirstOrDefaultAsync(cancellationToken);

                if (wizytaToUpdate == null)
                {
                    throw new ObjectNotExistInDbException(request.WizytaId, "Wizyta");
                };

                var wizyta = _mapper.Map<UpdateVisitCommand, Wizyta>(request, wizytaToUpdate); //zmapowanie zamiast tradycyjnego przypisania jak poniżej (musi być Id zmapowane w Command)
                //kontrahent.NazwaFirmy = request.NazwaFirmy;
                //kontrahent.Ulica = request.Ulica;
                //kontrahent.NumerBudynku = request.NumerBudynku;
                //kontrahent.NumerLokalu = request.NumerLokalu;
                //kontrahent.Nip = request.Nip;

                _context.Wizyty.Update(wizyta);
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
