using Daylon.BicycleStore.Communication.Request;

namespace Daylon.BicycleStore.Stock.Application.UseCases.Bicycle
{
    public interface IRegisterBicycleUseCase
    {
        public Task<Domain.Entity.Bicycle> ExecuteRegisterBicycleAsync(RequestRegisterBicycleJson request);
        public Task<Domain.Entity.Bicycle> ExecuteUpdateBicycleAsync(RequestUpdateBicycleJson request);

    }
}
