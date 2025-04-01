using Daylon.BicycleStore.Stock.Domain.Entity;
using Daylon.BicycleStore.Stock.Domain.Repositories.Bicycle;
using Microsoft.EntityFrameworkCore;

namespace Daylon.BicycleStore.Stock.Infrastructure.DataAccess.Repositories
{
    public class BicycleRepository : IBicycleRepository
    {
        private readonly BicycleStoreDbContext _dbContext;

        public BicycleRepository(BicycleStoreDbContext dbContext) => _dbContext = dbContext
            ?? throw new ArgumentNullException(nameof(dbContext));

        // DB

        private async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        public async Task AddAsync(Bicycle bicycle)
        {
            await _dbContext.Bicycles.AddAsync(bicycle);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(Bicycle bicycle)
        {
            _dbContext.Bicycles.Update(bicycle);
            await SaveChangesAsync();
        }

        // GET

        public async Task<List<Bicycle>> GetBicyclesAsync() => await _dbContext.Bicycles.ToListAsync();

        public async Task<Bicycle> GetBicycleByIdAsync(Guid id)
        {
            return await _dbContext.Bicycles.FindAsync(id)
                ?? throw new Exception($"Bicycle with id {id} not found");
        }

        // DELETE

        public async Task DeleteAsync(Bicycle bicycle)
        {
            _dbContext.Bicycles.Remove(bicycle);
            await SaveChangesAsync();
        }
    }
}
