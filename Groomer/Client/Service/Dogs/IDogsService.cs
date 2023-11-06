//using Groomer.Shared.Dogs.Commands;
using Groomer.Shared.Dogs.Queries.AllDogsQuery;

namespace Groomer.Client.Service.Dogs
{
    public interface IDogsService
    {
        Task<PsyList> GetAllDogsAsync();
        //Task<List<DogForListVm>> GetAllDogsAsync();
        //Task AddDogAsync(AddDogVM dog);
    }
}
