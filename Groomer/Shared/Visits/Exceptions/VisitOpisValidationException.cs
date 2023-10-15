using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Shared.Visits.Exceptions
{
    public class VisitOpisValidationException : Exception
    {
        public VisitOpisValidationException()
            : base(message:"Description has been not validated properly!")
        {

        }
    }
}
