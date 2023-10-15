using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Shared.Customers.Exceptions
{
    public class CustomerNullException : Exception
    {
        public CustomerNullException()
            : base(message: "Null customer error occured!")
        {

        }
    }
}
