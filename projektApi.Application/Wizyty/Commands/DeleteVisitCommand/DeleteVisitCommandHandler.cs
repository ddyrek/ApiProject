using MediatR;
using Microsoft.EntityFrameworkCore;
using projektApi.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Wizyty.Commands.DeleteVisitCommand
{
    public class DeleteVisitCommandHandler : IRequestHandler<DeleteVisitCommand>
    {
        private readonly IProjektApiDbContext _context;

        public DeleteVisitCommandHandler(IProjektApiDbContext projektDbContext)
        {
            _context = projektDbContext;
        }
        public async Task<Unit> Handle(DeleteVisitCommand request, CancellationToken cancellationToken)
        {
            var visit = await _context.Wizyty.Where(p => p.Id == request.VisitId).FirstOrDefaultAsync(cancellationToken);

            _context.Wizyty.Remove(visit);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
