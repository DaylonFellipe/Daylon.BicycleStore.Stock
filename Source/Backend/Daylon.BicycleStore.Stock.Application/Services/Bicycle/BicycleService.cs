using Daylon.BicycleStore.Communication.Request;
using Daylon.BicycleStore.Stock.Application.DTO.BicycleDTO;
using Daylon.BicycleStore.Stock.Application.Interface;
using Daylon.BicycleStore.Stock.Application.UseCases.Bicycle;
using Daylon.BicycleStore.Stock.Domain.Repositories.Bicycle;

namespace Daylon.BicycleStore.Stock.Application.Services.Bicycle
{
    public class BicycleService : IBicycleService
    {
        private readonly IBicycleRepository _bicycleRepository;
        private readonly IRegisterBicycleUseCase _useCase;

        public BicycleService(
            IBicycleRepository bicycleRepository,
            IRegisterBicycleUseCase UseCase
            )
        {
            _bicycleRepository = bicycleRepository;
            _useCase = UseCase;
        }

        public async Task<List<Domain.Entity.Bicycle>> GetBicyclesAsync()
        {
            var bicycles = await _bicycleRepository.GetBicyclesAsync();

            return bicycles;
        }

        public async Task<BicycleDTO> RegisterBicycleAsync(RequestRegisterBicycleJson request)
        {
            var bicycle = await _useCase.ExecuteRegisterBicycleAsync(request);

            var result = new BicycleDTO
            {
                Name = bicycle.Name,
                Description = bicycle.Description,
                Brand = bicycle.Brand,
                Model = bicycle.Model,
                Color = bicycle.Color,
                Price = bicycle.Price
            };

            return result;
        }
    }
}
