using Groomer.Shared.Visits.Commands;
using Groomer.Shared.Visits.Exceptions;

namespace Groomer.Client.Service.Visits
{
    public partial class VisitsService : IVisitsService
    {
        public static void ValidateVisit(AddVisitVM visit)
        {
            if (visit == null)
            {
                //throw new Exception("Post is null");
                throw new VisitNullException();
            }
            if (visit.Opis.Length <= 10)
            {
                //throw new Exception("Description of Visit is too short!");
                throw new VisitOpisValidationException();
            }
        }
    }
}
