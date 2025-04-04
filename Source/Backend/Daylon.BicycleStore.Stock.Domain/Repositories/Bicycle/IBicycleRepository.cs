using Daylon.BicycleStore.Stock.Domain.Entity;
using Daylon.BicycleStore.Stock.Domain.Repositories.Bicycle;

namespace Daylon.BicycleStore.Stock.Domain.Repositories.Bicycle
{
    public interface IBicycleRepository
    {
        // GET
        Task<List<Entity.Bicycle>> GetBicyclesAsync();

        Task<Entity.Bicycle?> GetBicycleByIdAsync(Guid id);

        // POST

        Task AddAsync(Entity.Bicycle bicycle);

        // PUT

        Task UpdateAsync(Entity.Bicycle bicycle);

        // DELETE

        Task DeleteAsync(Entity.Bicycle bicycle);
    }
}
