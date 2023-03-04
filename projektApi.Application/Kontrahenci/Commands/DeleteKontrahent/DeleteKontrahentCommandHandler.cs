using MediatR;
using Microsoft.EntityFrameworkCore;
using projektApi.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Kontrahenci.Commands.DeleteKontrahent
{
    public class DeleteKontrahentCommandHandler : IRequestHandler<DeleteKontrahentCommand>
    {
        private readonly IProjektApiDbContext _context;

        public DeleteKontrahentCommandHandler(IProjektApiDbContext projektDbContext)
        {
            _context = projektDbContext;
        }
        public async Task<Unit> Handle(DeleteKontrahentCommand request, CancellationToken cancellationToken)
        {
            var kontrahent = await _context.Kontrahenci.Where(p => p.Id == request.KontrahentId).FirstOrDefaultAsync(cancellationToken);

            _context.Kontrahenci.Remove(kontrahent);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
