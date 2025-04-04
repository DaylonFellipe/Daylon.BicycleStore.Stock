using Daylon.BicycleStore.Communication.Request;
using Daylon.BicycleStore.Stock.Application.DTO.BicycleDTO;

namespace Daylon.BicycleStore.Stock.Application.Interface
{
    public interface IBicycleService
    {
        // GET

        Task<List<Domain.Entity.Bicycle>> GetBicyclesAsync();

        Task<Domain.Entity.Bicycle> GetBicycleByIdAsync(Guid id);

        // POST

        Task<BicycleDTO> RegisterBicycleAsync(RequestRegisterBicycleJson request);

        // PUT

        Task<BicycleDTO> UpdateBicycleAsync(RequestUpdateBicycleJson request);

        // DELETE

        Task DeleteBicycleAsync(Guid id);
    }
}
