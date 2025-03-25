using Daylon.BicycleStore.Stock.Domain.Entity;

namespace Daylon.BicycleStore.Stock.Domain.Repositories.Bicycle
{
    public interface IBicycleRepository
    {
        public Task<List<Entity.Bicycle>> GetBicyclesAsync();
    }
}
