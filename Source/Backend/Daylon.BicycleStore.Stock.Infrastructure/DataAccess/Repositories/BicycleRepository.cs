using Daylon.BicycleStore.Stock.Domain.Entity;
using Daylon.BicycleStore.Stock.Domain.Repositories.Bicycle;
using Microsoft.EntityFrameworkCore;

namespace Daylon.BicycleStore.Stock.Infrastructure.DataAccess.Repositories
{
    public class BicycleRepository : IBicycleRepository
    {
        private readonly BicycleStoreDbContext _dbContext;

        public BicycleRepository(BicycleStoreDbContext dbContext) => _dbContext = dbContext;

        public async Task<List<Bicycle>> GetBicyclesAsync() => await _dbContext.Bicycles.ToListAsync();
    }
}
