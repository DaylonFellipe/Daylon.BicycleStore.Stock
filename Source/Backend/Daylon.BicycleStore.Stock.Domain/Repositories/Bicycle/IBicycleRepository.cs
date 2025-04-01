using Daylon.BicycleStore.Stock.Domain.Entity;
using Daylon.BicycleStore.Stock.Domain.Repositories.Bicycle;

namespace Daylon.BicycleStore.Stock.Domain.Repositories.Bicycle
{
    public interface IBicycleRepository
    {
        // DB
        public Task AddAsync(Entity.Bicycle bicycle);

        public Task UpdateAsync(Entity.Bicycle bicycle);

        // GET

        public Task<List<Entity.Bicycle>> GetBicyclesAsync();

        public Task<Entity.Bicycle> GetBicycleByIdAsync(Guid id);

        // DELETE

        public Task DeleteAsync(Entity.Bicycle bicycle);
    }
}
