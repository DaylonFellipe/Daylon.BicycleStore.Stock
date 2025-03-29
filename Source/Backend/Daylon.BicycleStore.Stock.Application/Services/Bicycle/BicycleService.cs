using Daylon.BicycleStore.Communication.Request;
using Daylon.BicycleStore.Stock.Application.DTO.BicycleDTO;
using Daylon.BicycleStore.Stock.Application.Interface;
using Daylon.BicycleStore.Stock.Application.UseCases.Bicycle;
using Daylon.BicycleStore.Stock.Domain.Entity.Enum;
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

        // GET
        public async Task<List<Domain.Entity.Bicycle>> GetBicyclesAsync()
        {
            var bicycles = await _bicycleRepository.GetBicyclesAsync();

            return bicycles;
        }

        public async Task<Domain.Entity.Bicycle> GetBicycleByIdAsync(Guid id)
        {
            var bicycle = await _bicycleRepository.GetBicycleByIdAsync(id);

            return bicycle;
        }

        // POST

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

        //PUT

        public async Task<BicycleDTO> UpdateBicycleAsync(RequestUpdateBicycleJson request)
        {
           var bicycle = await _useCase.ExecuteUpdateBicycleAsync(request);

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

        // DELETE

        public async Task DeleteBicycleAsync(Guid id)
        {
            var bicycle = await _bicycleRepository.GetBicycleByIdAsync(id);

            await _bicycleRepository.DeleteBicycleAsync(bicycle);
        }
    }
}
