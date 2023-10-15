using Groomer.Client.Brokers.API;
using Groomer.Shared.Customers.Commands;
using Groomer.Shared.Customers.Exceptions;

namespace Groomer.Client.Service.Customers
{
    public partial class CustomersService : ICustomersService
    {
        private readonly IApiBroker apiBroker;

        public CustomersService(IApiBroker apiBroker)
        {
            this.apiBroker = apiBroker;
        }

        //public async Task<List<CustomerForListVm>> GetAllCustomersAsync()
        //{

        //    return await apiBroker.GetAllCustomersAsync();

        //}

        public async Task AddCustomerAsync(AddCustomerVM customer)
        {
            //dodoatkowa walidacja VM wysyłanych do API
            //szczególnie przydatna gdy nie jestesmy autorami API
            ValidateCustomer(customer);

            try
            {
                await apiBroker.AddCustomerAsync(customer);
            }
            catch (Exception ex)
            {

                throw new CustomerBadRequestException(ex);
            }
        }
    }
}
