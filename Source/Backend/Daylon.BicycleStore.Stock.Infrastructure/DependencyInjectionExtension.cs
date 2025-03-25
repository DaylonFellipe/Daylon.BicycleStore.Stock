using Daylon.BicycleStore.Stock.Domain.Repositories.Bicycle;
using Daylon.BicycleStore.Stock.Infrastructure.DataAccess;
using Daylon.BicycleStore.Stock.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Daylon.BicycleStore.Stock.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BicycleStoreDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"));
            });
        }

        public static void AddRepositories( IServiceCollection services)
        {
            services.AddScoped<IBicycleRepository, BicycleRepository>();
        }
    }
}
