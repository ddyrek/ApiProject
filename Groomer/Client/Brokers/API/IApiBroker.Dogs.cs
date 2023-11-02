using Groomer.Shared.Dogs.Commands;
using Groomer.Shared.Dogs.Queries.AllDogsQuery;

namespace Groomer.Client.Brokers.API
{
    public partial interface IApiBroker
    {
        Task<PsyList> GetAllDogsAsync();
        //Task<List<DogForListVm>> GetAllDogsAsync();
        //Task AddDogsAsync(AddDogsVM dog);
    }
}
