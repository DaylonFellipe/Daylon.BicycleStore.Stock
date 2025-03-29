using Daylon.BicycleStore.Communication.Request;
using Daylon.BicycleStore.Stock.Application.DTO.BicycleDTO;

namespace Daylon.BicycleStore.Stock.Application.Interface
{
    public interface IBicycleService
    {
        // GET

        public Task<List<Domain.Entity.Bicycle>> GetBicyclesAsync();

        public Task<Domain.Entity.Bicycle> GetBicycleByIdAsync(Guid id);

        // POST

        public Task<BicycleDTO> RegisterBicycleAsync(RequestRegisterBicycleJson request);

        // PUT

        public Task<BicycleDTO> UpdateBicycleAsync(RequestUpdateBicycleJson request);

        // DELETE

        public Task DeleteBicycleAsync(Guid id);
    }
}
