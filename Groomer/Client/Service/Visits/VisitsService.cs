using Groomer.Client.Brokers.API;
using Groomer.Shared.Visits.Commands;
using Groomer.Shared.Visits.Exceptions;
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

        public async Task<HttpResponseMessage> AddVisitAsync(AddVisitVM visit)
        {
            //dodoatkowa walidacja VM wysyłanych do API
            //szczególnie przydatna gdy nie jestesmy autorami API
            ValidateVisit(visit);

            try
            {
                return await apiBroker.AddVisitAsync(visit);
            }
            catch (Exception ex)
            {

                throw new VisitBadRequestException(ex);
            }
        }
    }
}
