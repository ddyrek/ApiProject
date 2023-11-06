using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Shared.Dogs.Exceptions
{
    public class DogNullException : Exception
    {
        public DogNullException()
            : base(message: "Null dog error occured!")
        {

        }
    }
}
