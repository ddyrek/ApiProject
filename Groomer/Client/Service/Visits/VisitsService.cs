using Groomer.Client.Brokers.API;
using Groomer.Shared.Visits.Commands;
using Groomer.Shared.Visits.Exceptions;
using Groomer.Shared.Visits.Queries.AllVisitsQuery;

namespace Groomer.Client.Service.Visits
{
    //VisistService i ogólnie Service - to warstwa usług, która powinna implementować logikę biznesową aplikacji
    public partial class VisitsService : IVisitsService
    {
        //ApiBroker - obsuga tylko żadań HTTP
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

        public async Task<HttpResponseMessage> DeleteVisitAsync(int visitId)
        {
            try
            {
                return await apiBroker.DeleteVisitAsync(visitId);
            }
            catch (Exception ex)
            {

                throw new VisitBadRequestException(ex);
            }
        }

        public async Task<HttpResponseMessage> UpdateVisitAsync(int visitId, UpdateVisitVM updateVisit)
        {
            //dodoatkowa walidacja VM wysyłanych do API
            //szczególnie przydatna gdy nie jestesmy autorami API
            ValidateEditVisit(updateVisit);

            try
            {
                return await apiBroker.UpdateVisitAsync(visitId, updateVisit);
            }
            catch (Exception ex)
            {

                throw new VisitBadRequestException(ex);
            }
        }
    }
}
