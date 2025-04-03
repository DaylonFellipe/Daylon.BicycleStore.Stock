using Daylon.BicycleStore.Stock.Application.Interface;
using Daylon.BicycleStore.Stock.Application.Services.Bicycle;
using Daylon.BicycleStore.Stock.Application.UseCases.Bicycle;
using Microsoft.Extensions.DependencyInjection;

namespace Daylon.BicycleStore.Stock.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            AddServices(services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IBicycleService, BicycleService>();
            services.AddScoped<IBicycleUseCase, BicycleUseCase>();
        }
    }
}
