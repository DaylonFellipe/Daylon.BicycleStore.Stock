namespace Daylon.BicycleStore.Stock.Application.Interface
{
    public interface IBicycleService
    {
        public Task<List<Domain.Entity.Bicycle>> GetBicyclesAsync();
    }
}
