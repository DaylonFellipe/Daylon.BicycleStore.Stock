using Daylon.BicycleStore.Stock.Domain.Entity;

namespace Daylon.BicycleStore.Stock.Domain.Repositories.Bicycle
{
    public interface IBicycleRepository
    {
        // DB

        public Task SaveChangesAsync();

        public Task AddAsync(Entity.Bicycle bicycle);

        public Task UpdateTaskAsync(Entity.Bicycle bicycle);

        // GET

        public Task<List<Entity.Bicycle>> GetBicyclesAsync();

        public Task<Entity.Bicycle> GetBicycleByIdAsync(Guid id);

        // DELETE

        public Task DeleteBicycleByIdAsync(Guid id);
    }
}
