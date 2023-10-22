using Groomer.Shared.Customers.Commands;
using Groomer.Shared.Customers.Exceptions;

namespace Groomer.Client.Service.Customers
{
    public partial class CustomersService : ICustomersService
    {
        public static void ValidateCustomer(AddCustomerVM customer)
        {
            if (customer == null)
            {
                //throw new Exception("Customer is null");
                throw new CustomerNullException();
            }
            if (customer.Name.Length >= 40)
            {
                //throw new Exception("Name of Customer is too short!");
                throw new CustomerNameValidationException();
            }
        }
    }
}
