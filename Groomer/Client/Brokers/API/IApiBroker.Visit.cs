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
        Task<HttpResponseMessage> DeleteVisitAsync(int visitId);
        Task<HttpResponseMessage> PatchAsync<T>(string relativeUrl, T content);
        Task<HttpResponseMessage> UpdateVisitAsync(int visitId, AddVisitVM updateVisit); //UpdateVisistVM
    }
}
