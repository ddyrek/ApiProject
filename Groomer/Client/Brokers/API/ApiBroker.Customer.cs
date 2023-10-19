using Groomer.Shared.Customers.Commands;

namespace Groomer.Client.Brokers.API
{
    public partial class ApiBroker
    {
        private const string CustomerRelativeUrl = "https://localhost:7233/api/klienci";
        //private const string CustomerRelativeUrl = "api/klienci";
        //public async Task<List<CustomerForListVm>> GetAllCustomersAsync() =>
        //    await this.GetAsync<List<CustomerForListVm>>(CustomerRelativeUrl);

        //public async Task AddCustomerAsync(AddCustomerVM customer) =>
        //    await this.PostAsync<AddCustomerVM>(CustomerRelativeUrl, customer);

        public async Task AddCustomerAsync(AddCustomerVM customer) =>
            await this.PostAsync<AddCustomerVM>(CustomerRelativeUrl, customer);
    }
}
