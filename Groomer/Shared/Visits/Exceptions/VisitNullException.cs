using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Shared.Visits.Exceptions
{
    public class VisitNullException : Exception
    {
        public VisitNullException() 
            : base(message:"Null visit error occured!")
        {

        }
    }
}
