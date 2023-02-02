using MediatR;
using Microsoft.EntityFrameworkCore;
using projektApi.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Klienci.Commands.DeleteKlient
{
    public class DeleteKlientCommandHandler : IRequestHandler<DeleteKlientCommand>
    {
        private readonly IProjektApiDbContext _context;

        public DeleteKlientCommandHandler(IProjektApiDbContext projektApiDbContext)
        {
            _context = projektApiDbContext;
        }
        public async Task<Unit> Handle(DeleteKlientCommand request, CancellationToken cancellationToken)
        {
            var director = await _context.Klienci.Where(p => p.Id == request.KlentId).FirstOrDefaultAsync(cancellationToken);

            _context.Klienci.Remove(director);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
