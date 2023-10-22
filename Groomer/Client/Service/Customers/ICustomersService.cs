using Groomer.Shared.Customers.Commands;

namespace Groomer.Client.Service.Customers
{
    public interface ICustomersService
    {
        Task AddCustomerAsync(AddCustomerVM customer);
        // Dodaj inne metody lub właściwości, jeśli są wymagane.
    }
}
