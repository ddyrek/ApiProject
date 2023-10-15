using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Shared.Visits.Exceptions
{
    public class VisitBadRequestException : Exception
    {
        //ten custom excepion wyswietli nam informacje bezpośrednią z meesege
        //oraz informację w inner excetion (Exeception ex),
        //dzięki temu nie musimy przeszukiwac całego stack trace w celu znalezienia błędu
        public VisitBadRequestException(Exception ex)
            : base(message: "Bad request occured when trying to send visit!", ex)
        {

        }
    }
}
