using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Domain.Excpetions
{
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException(Type objectType, string propertyName, string description = "")
            : base($"Found problem with {objectType.ToString()} {propertyName}. Info = {description}", new Exception())
        {

        }
    }
}
