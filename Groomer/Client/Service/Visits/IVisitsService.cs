using Groomer.Shared.Visits.Commands;
using Groomer.Shared.Visits.Queries.AllVisitsQuery;

namespace Groomer.Client.Service.Visits
{
    public interface IVisitsService
    {
        Task<List<VisitForListVm>> GetAllVisitsAsync();
        Task<HttpResponseMessage> AddVisitAsync(AddVisitVM visit);
    }
}
