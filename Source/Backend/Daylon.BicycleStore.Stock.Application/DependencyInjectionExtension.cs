using Daylon.BicycleStore.Stock.Application.Interface;
using Daylon.BicycleStore.Stock.Application.Services.Bicycle;
using Microsoft.Extensions.DependencyInjection;

namespace Daylon.BicycleStore.Stock.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddServices(services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IBicycleService, BicycleService>();
        }
    }
}
