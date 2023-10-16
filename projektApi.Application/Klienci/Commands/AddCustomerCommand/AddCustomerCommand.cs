using Groomer.Shared.Customers.Commands;
using Groomer.Shared.Visits.Commands;
using MediatR;
using projektApi.Application.Common.Interfaces;
using projektApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Application.Klienci.Commands.AddCustomerCommand
{
    public class AddCustomerCommand : IRequest<int>
    {
        public AddCustomerVM Customer { get; set; }
    }

    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, int>
    {
        private readonly IProjektApiDbContext context;

        public AddCustomerCommandHandler(IProjektApiDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = new Klient()
                {
                    KlientName = new Domain.ValueObjects.PersonName() { Name = request.Customer.Name, Surname = request.Customer.Surname },
                    PhoneNumber = request.Customer.PhoneNumber,
                    KontrahentId = request.Customer.KontrahentId
                };
                context.Klienci.Add(customer);
                await context.SaveChangesAsync(cancellationToken);
                return customer.Id;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
