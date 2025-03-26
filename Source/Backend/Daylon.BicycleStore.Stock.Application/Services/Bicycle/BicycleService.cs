using Daylon.BicycleStore.Stock.Application.Interface;
using Daylon.BicycleStore.Stock.Domain.Repositories.Bicycle;

namespace Daylon.BicycleStore.Stock.Application.Services.Bicycle
{
    public class BicycleService : IBicycleService
    {
        private readonly IBicycleRepository _bicycleRepository;

        public BicycleService(IBicycleRepository bicycleRepository)
        {
            _bicycleRepository = bicycleRepository;
        }

        public async Task<List<Domain.Entity.Bicycle>> GetBicyclesAsync()
        {
            var bicycles = await _bicycleRepository.GetBicyclesAsync();

            return bicycles;
        }


    }
}
