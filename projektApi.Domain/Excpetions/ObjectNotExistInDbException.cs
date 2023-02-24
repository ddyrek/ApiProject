using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Domain.Excpetions
{
    public class ObjectNotExistInDbException : Exception
    {
        public ObjectNotExistInDbException(int id, string objectName = "Object")
       : base($"{objectName} with Id = {id} not found in database", new Exception())
        {

        }
    }
}
