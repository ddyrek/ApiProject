using Groomer.Client.Brokers.API;
using Groomer.Shared.Visits.Queries.AllVisitsQuery;

namespace Groomer.Client.Service.Visits
{
    public partial class VisitsService : IVisitsService
    {
        private readonly IApiBroker apiBroker;

        public VisitsService(IApiBroker apiBroker)
        {
            this.apiBroker = apiBroker;
        }

        public async Task<List<VisitForListVm>> GetAllVisitsAsync()
        {

            return await apiBroker.GetAllVisitsAsync();

        }
    }
}
