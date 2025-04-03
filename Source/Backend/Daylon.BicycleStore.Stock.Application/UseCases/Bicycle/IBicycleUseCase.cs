using Daylon.BicycleStore.Communication.Request;

namespace Daylon.BicycleStore.Stock.Application.UseCases.Bicycle
{
    public interface IBicycleUseCase
    {
         Task<Domain.Entity.Bicycle> ExecuteRegisterBicycleAsync(RequestRegisterBicycleJson request);

         Task<Domain.Entity.Bicycle> ExecuteUpdateBicycleAsync(RequestUpdateBicycleJson request);
    }
}
