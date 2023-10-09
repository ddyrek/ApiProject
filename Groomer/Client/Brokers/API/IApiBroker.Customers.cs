using Groomer.Shared.Customers.Commands;

namespace Groomer.Client.Brokers.API
{
    public partial interface IApiBroker
    {
        //Task<List<CustomerForListVm>> GetAllPostsAsync();
        Task AddPostAsync(AddCustomerVM post);
    }
}
