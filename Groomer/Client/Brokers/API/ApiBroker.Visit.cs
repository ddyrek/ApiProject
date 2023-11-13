using Groomer.Shared.Visits.Commands;
using Groomer.Shared.Visits.Queries.AllVisitsQuery;

namespace Groomer.Client.Brokers.API
{
    public partial class ApiBroker
    {
		private const string VisitRelativeUrl = "https://localhost:7233/api/wizyty";
		public async Task<List<VisitForListVm>> GetAllVisitsAsync() =>
			await this.GetAsync<List<VisitForListVm>>(VisitRelativeUrl);

		public async Task<HttpResponseMessage> AddVisitAsync(AddVisitVM visit) =>
			await this.PostAsync<AddVisitVM>(VisitRelativeUrl, visit);
	}
}
