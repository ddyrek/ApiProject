using AutoMapper;
using MediatR;
using projektApi.Application.Common.Interfaces;
using projektApi.Domain.Entities;
using projektApi.Domain.Excpetions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Kontrahenci.Commands.CreateKontrahent
{
   // public class CreateKontrahentCommandHandler : IRequestHandler<CreateKontrahentCommand, int>
    //{
        //private readonly IProjektApiDbContext _context;
        //public CreateKontrahentCommandHandler(IProjektApiDbContext projectApiDbContext)
        //{
        //    _context = projectApiDbContext;
        //}
        //public async Task<int> Handle(CreateKontrahentCommand request, CancellationToken cancellationToken)
        //{
        //    Kontrahent kontrahent = new()
        //    {
        //        //KontrahentName = new Domain.ValueObjects.PersonName() { Name = request.Name, Surname = request.Surname },
        //        NazwaFirmy = request.NazwaFirmy,
        //        Ulica = request.Ulica,
        //        //StatusId = 1,
        //        NumerBudynku = request.NumerBudynku,
        //        NumerLokalu = request.NumerLokalu,
        //        Nip = request.Nip,
        //        //CreatedBy = request.CreatedBy,
        //        //Created = DateTime.Now
        //    };

        //    _context.Kontrahenci.Add(kontrahent);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return kontrahent.Id;
        //}

        public class CreateKontrahentCommandHandler : IRequestHandler<CreateKontrahentCommand, int>
        {
            private readonly IProjektApiDbContext _context;
            private IMapper _mapper;

            public CreateKontrahentCommandHandler(
                IProjektApiDbContext projectApiDbContext,
                IMapper mapper)
            {
                _context = projectApiDbContext;
                _mapper = mapper;
            }
            public async Task<int> Handle(CreateKontrahentCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    await ValidRequest(request);
                    var kontrahent = new Kontrahent();
                    _context.Kontrahenci.Add(kontrahent);

                    await _context.SaveChangesAsync(cancellationToken);

                    return kontrahent.Id;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            private Task ValidRequest(CreateKontrahentCommand request)
            {
                if (string.IsNullOrEmpty(request.NazwaFirmy))
                    throw new InvalidRequestException(request.GetType(), "NazwaFirmy", "Name is null or empty");
                //if (request.Name?.Length > 100)
                //    throw new InvalidRequestException(request.GetType(), "Name", "Name is longer then 100 chars");
                //if (request.Description == null)
                //    throw new InvalidRequestException(request.GetType(), "Description", "Description is null");
                //if (request.Description.Length > 100)
                //    throw new InvalidRequestException(request.GetType(), "Description", "Description is longer then 100 chars");
                //if (request.City == null)
                //    throw new InvalidRequestException(request.GetType(), "City", "City is null");
                //if (request.City.Length > 25)
                //    throw new InvalidRequestException(request.GetType(), "City", "City is longer then 25 chars");
                //if (request.PostCode == null)
                //    throw new InvalidRequestException(request.GetType(), "PostCode", "PostCode is null");
                //if (request.PostCode.Length > 10)
                //    throw new InvalidRequestException(request.GetType(), "PostCode", "PostCode is longer then 10 chars");
                //if (string.IsNullOrEmpty(request.Street))
                //    throw new InvalidRequestException(request.GetType(), "Street", "Street is null or empty");
                //if (request.Street.Length > 25)
                //    throw new InvalidRequestException(request.GetType(), "Street", "Street is longer then 25 chars");
                //if (string.IsNullOrEmpty(request.HouseNumber))
                //    throw new InvalidRequestException(request.GetType(), "HouseNumber", "HouseNumber is null");
                //if (request.HouseNumber.Length > 5)
                //    throw new InvalidRequestException(request.GetType(), "HouseNumber", "HouseNumber is longer then 5 chars");
                //if (request.FlatNumber == null)
                //    throw new InvalidRequestException(request.GetType(), "FlatNumber", "FlatNumber is null");
                //if (request.FlatNumber.Length > 20)
                //    throw new InvalidRequestException(request.GetType(), "FlatNumber", "FlatNumber is longer then 20 chars");
                //if (request.PhoneNumber == null)
                //    throw new InvalidRequestException(request.GetType(), "PhoneNumber", "PhoneNumber is null");
                //if (request.PhoneNumber.Length < 7)
                //    throw new InvalidRequestException(request.GetType(), "PhoneNumber", "PhoneNumber is shorter then 7 chars");
                //if (request.PhoneNumber.Length > 10)
                //    throw new InvalidRequestException(request.GetType(), "PhoneNumber", "PhoneNumber is longer then 10 chars");
                //if (request.Email == null)
                //    throw new InvalidRequestException(request.GetType(), "Email", "Email is null");
                //if (!request.Email.Contains('@'))
                //    throw new InvalidRequestException(request.GetType(), "Email", "Email is not email");

                return Task.CompletedTask;
            }
        }
}
