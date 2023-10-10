namespace Groomer.Client.Brokers.API
{
    public partial class ApiBroker
    {
		private const string CustomerRelativeUrl = "api/wizyty";
		public async Task<List<VisitForListVm>> GetAllVisitsAsync() =>
			await this.GetAsync<List<VisitForListVm>>(PostRelativeUrl);

		//public async Task AddVisitAsync(AddVisitVM post) =>
		//	await this.VisitAsync<AddVisitVM>(PostRelativeUrl, post);
	}
}
