using Groomer.Shared.Customers.Commands;
using Groomer.Shared.Visits.Queries.AllVisitsQuery;

namespace Groomer.Client.Brokers.API
{
    public partial interface IApiBroker
    {
        Task<List<VisitForListVm>> GetAllPostsAsync();
        //Task AddVisitAsync(AddVisitVM post);
    }
}
