//using Groomer.Shared.Visits.Commands;
using Groomer.Shared.Visits.Commands;
using Groomer.Shared.Visits.Queries.AllVisitsQuery;

namespace Groomer.Client.Brokers.API
{
    public partial interface IApiBroker
    {
        Task<List<VisitForListVm>> GetAllVisitsAsync();
        //Task AddVisitAsync(AddVisitVM visit);
        Task<HttpResponseMessage> AddVisitAsync(AddVisitVM visit);
    }
}
