using Daylon.BicycleStore.Communication.Request;
using Daylon.BicycleStore.Stock.Application.DTO.BicycleDTO;

namespace Daylon.BicycleStore.Stock.Application.Interface
{
    public interface IBicycleService
    {
        // GET

        public Task<List<Domain.Entity.Bicycle>> GetBicyclesAsync();

        // POST

        public Task<BicycleDTO> RegisterBicycleAsync(RequestRegisterBicycleJson request);

    }
}
