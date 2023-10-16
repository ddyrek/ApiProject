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
                var customer = new Customer()
                {
                    Opis = request.Customer.Name,
                    GodzinaWizyty = request.Customer.GodzinaWizyty,
                    DataWizyty = request.Customer.DataWizyty,
                    Kwota = request.Customer.Kwota,
                    PiesId = request.Customer.PiesId,
                };
                context.Wizyty.Add(Customer);
                await context.SaveChangesAsync(cancellationToken);
                return Customer.Id;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
