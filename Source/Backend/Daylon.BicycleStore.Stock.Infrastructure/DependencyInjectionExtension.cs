using Daylon.BicycleStore.Stock.Domain.Repositories.Bicycle;
using Daylon.BicycleStore.Stock.Domain.Services.RabbitMQ;
using Daylon.BicycleStore.Stock.Exceptions;
using Daylon.BicycleStore.Stock.Infrastructure.DataAccess;
using Daylon.BicycleStore.Stock.Infrastructure.DataAccess.Repositories;
using Daylon.BicycleStore.Stock.Infrastructure.Services.RabbitMQ.Bus;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Daylon.BicycleStore.Stock.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
            AddMassTransitService(services, configuration);
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServerConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(ResourceMessagesException.INVALID_CONNECTION_STRING);

            services.AddDbContext<BicycleStoreDbContext>(options =>
                options.UseSqlServer(connectionString));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IBicycleRepository, BicycleRepository>();
        }

        private static void AddMassTransitService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPublishBus, PublishBus>();

            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.UsingRabbitMq((ctx, cfg) =>
                {
                    var rabbitMQSettings = configuration.GetSection("RabbitMQ");

                    cfg.Host(new Uri(rabbitMQSettings.GetRequiredSection("Uri").Value!), host =>
                       {
                           host.Username(rabbitMQSettings.GetRequiredSection("Username").Value!);
                           host.Password(rabbitMQSettings.GetRequiredSection("Password").Value!);
                       });

                    cfg.ConfigureEndpoints(ctx);
                });
            });
        }
    }
}
