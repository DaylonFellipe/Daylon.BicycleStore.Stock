using Daylon.BicycleStore.Stock.Domain.Repositories.Bicycle;

namespace Daylon.BicycleStore.Stock.Application.Services.Bicycle
{
    public class BicycleService
    {
        private readonly IBicycleRepository _bicycleRepository;

        public BicycleService(IBicycleRepository bicycleRepository)
        {
            _bicycleRepository = bicycleRepository;
        }



    }
}
