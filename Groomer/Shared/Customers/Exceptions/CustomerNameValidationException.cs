﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Shared.Customers.Exceptions
{
    public class CustomerNameValidationException : Exception
    {
        public CustomerNameValidationException()
            : base(message: "Name has been not validated properly!")
        {

        }
    }
}
