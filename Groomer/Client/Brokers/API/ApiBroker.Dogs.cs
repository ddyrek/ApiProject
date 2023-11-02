using Groomer.Shared.Dogs.Commands;
using Groomer.Shared.Dogs.Queries.AllDogsQuery;

namespace Groomer.Client.Brokers.API
{
	public partial class ApiBroker
	{
		private const string DogRelativeUrl = "https://localhost:7233/api/psy";
		public async Task<PsyList> GetAllDogsAsync() =>
			await this.GetAsync<PsyList>(VisitRelativeUrl);
		//public async Task<List<DogForListVm>> GetAllDogsAsync() =>
		//	await this.GetAsync<List<DogForListVm>>(VisitRelativeUrl);

		//public async Task AddDogAsync(AddDogVM dog) =>
		//	await this.PostAsync<AddDogVM>(VisitRelativeUrl, dog);
	}
}
