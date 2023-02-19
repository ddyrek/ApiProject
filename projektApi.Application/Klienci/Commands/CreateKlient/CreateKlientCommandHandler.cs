using MediatR;
using projektApi.Application.Common.Interfaces;
using projektApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Klienci.Commands.CreateKlient
{
    public class CreateKlientCommandHandler : IRequestHandler<CreateKlientCommand, int>
    {
        private readonly IProjektApiDbContext _context;
        public CreateKlientCommandHandler(IProjektApiDbContext projectApiDbContext)
        {
            _context = projectApiDbContext;
        }
        public async Task<int> Handle(CreateKlientCommand request, CancellationToken cancellationToken)
        {
            Klient klient = new()
            {
                KlientName = new Domain.ValueObjects.PersonName() { Name = request.Name, Surname = request.Surname },
                PhoneNumber = request.PhoneNumber,
                //StatusId = 1,
                KontrahentId = request.KontrahentId,
                //Created = DateTime.Now
            };

            //DirectorBiography directorBiography = new()
            //{
            //    DoB = request.DoB,
            //    PlaceOfBirth = request.PlaceOfBirth,
            //    DirectorId = director.Id
            //};


            _context.Klienci.Add(klient);

            await _context.SaveChangesAsync(cancellationToken);

            return klient.Id;
        }
    }
}
