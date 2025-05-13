namespace Daylon.BicycleStore.Stock.Domain.Services.RabbitMQ
{
    public interface IPublishBus
    {
        Task PublishAsync<T>(T message, CancellationToken ct = default) where T : class;
    }
}
