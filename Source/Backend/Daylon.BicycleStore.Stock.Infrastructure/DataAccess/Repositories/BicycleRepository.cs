using Daylon.BicycleStore.Stock.Domain.Entity;
using Daylon.BicycleStore.Stock.Domain.Repositories.Bicycle;
using Microsoft.EntityFrameworkCore;

namespace Daylon.BicycleStore.Stock.Infrastructure.DataAccess.Repositories
{
    public class BicycleRepository : IBicycleRepository
    {
        private readonly BicycleStoreDbContext _dbContext;

        public BicycleRepository(BicycleStoreDbContext dbContext) => _dbContext = dbContext;

        // DB

        public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        public async Task AddAsync(Bicycle bicycle) => await _dbContext.Bicycles.AddAsync(bicycle);

        public async Task UpdateTaskAsync(Bicycle bicycle)
        {
            _dbContext.Bicycles.Update(bicycle);
            await SaveChangesAsync();
        }

        // GET

        public async Task<List<Bicycle>> GetBicyclesAsync() => await _dbContext.Bicycles.ToListAsync();

        public async Task<Bicycle> GetBicycleByIdAsync(Guid id)
        {
            var bicycle = await _dbContext.Bicycles.FirstOrDefaultAsync(b => b.Id == id);

            return bicycle ?? throw new Exception($"Bicycle with id {id} not found");
        }

        // DELETE

        public async Task DeleteBicycleAsync(Bicycle bicycle)
        {
            _dbContext.Bicycles.Remove(bicycle);

            await SaveChangesAsync();
        }
    }
}
 