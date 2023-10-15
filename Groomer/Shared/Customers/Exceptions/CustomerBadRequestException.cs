using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Shared.Customers.Exceptions
{
    public class CustomerBadRequestException : Exception
    {
        public CustomerBadRequestException(Exception ex)
            : base(message: "Bad request occured when trying to send visit!", ex)
        {

        }
    }
}
