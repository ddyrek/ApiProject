using Groomer.Client.Brokers.API;
using Groomer.Shared.Dogs.Exceptions;
using Groomer.Shared.Dogs.Queries.AllDogsQuery;

namespace Groomer.Client.Service.Dogs
{
    public partial class DogsService : IDogsService
    {
        private readonly IApiBroker apiBroker;

        public DogsService(IApiBroker apiBroker)
        {
            this.apiBroker = apiBroker;
        }

        public async Task<PsyList> GetAllDogsAsync()
        //public async Task<List<DogForListVm>> GetAllDogsAsync()
        {
            var allDogs = await apiBroker.GetAllDogsAsync();

            // Przefiltruj listę psów, zachowując tylko Id i Name
            var filteredDogs = allDogs.Psy.Select(p => new DogForListVm
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return new PsyList { Psy = filteredDogs };
            //return await apiBroker.GetAllDogsAsync();

        }

        //public async Task AddDogAsync(AddDogVM dog)
        //{
        //    //dodoatkowa walidacja VM wysyłanych do API
        //    //szczególnie przydatna gdy nie jestesmy autorami API
        //    ValidateDog(dog);

        //    try
        //    {
        //        await apiBroker.AddDogAsync(dog);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new DogBadRequestException(ex);
        //    }
        //}
    }
}
