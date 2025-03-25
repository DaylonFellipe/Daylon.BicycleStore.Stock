using Daylon.BicycleStore.Stock.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Daylon.BicycleStore.Stock.Infrastructure.DataAccess
{
    public class BicycleStoreDbContext : DbContext
    {
        public BicycleStoreDbContext(DbContextOptions<BicycleStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Bicycle> Bicycles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BicycleStoreDbContext).Assembly);
        }
    }
}
