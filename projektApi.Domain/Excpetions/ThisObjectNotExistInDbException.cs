using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Domain.Excpetions
{
    public class ThisObjectNotExistInDbException : Exception
    {
        public ThisObjectNotExistInDbException(string objectName = "Object")
            : base($"{objectName} not found in database", new Exception())
        {
        }
    }
}
