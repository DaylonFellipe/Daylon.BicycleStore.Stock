using Daylon.BicycleStore.Communication.Request;
using Daylon.BicycleStore.Stock.Application.DTO.BicycleDTO;
using Daylon.BicycleStore.Stock.Application.Interface;
using Daylon.BicycleStore.Stock.Application.UseCases.Bicycle;
using Daylon.BicycleStore.Stock.Domain.Repositories.Bicycle;
using Daylon.BicycleStore.Stock.Exceptions;

namespace Daylon.BicycleStore.Stock.Application.Services.Bicycle
{
    public class BicycleService : IBicycleService
    {
        private readonly IBicycleRepository _bicycleRepository;
        private readonly IBicycleUseCase _bicycleUseCase;

        public BicycleService(
            IBicycleRepository bicycleRepository,
            IBicycleUseCase bicycleUseCase
            )
        {
            _bicycleRepository = bicycleRepository;
            _bicycleUseCase = bicycleUseCase;
        }

        // GET
        public async Task<List<Domain.Entity.Bicycle>> GetBicyclesAsync()
            => await _bicycleRepository.GetBicyclesAsync();

        public async Task<Domain.Entity.Bicycle> GetBicycleByIdAsync(Guid id)
            => await _bicycleRepository.GetBicycleByIdAsync(id)
            ?? throw new Exception(ResourceMessagesException.BICYCLE_NOT_FOUND);

        // POST

        public async Task<BicycleDTO> RegisterBicycleAsync(RequestRegisterBicycleJson request)
        {
            var bicycle = await _bicycleUseCase.ExecuteRegisterBicycleAsync(request);

            return MapToDTO(bicycle);
        }

        // PUT

        public async Task<BicycleDTO> UpdateBicycleAsync(RequestUpdateBicycleJson request)
        {
            var bicycle = await _bicycleUseCase.ExecuteUpdateBicycleAsync(request);

            return MapToDTO(bicycle);
        }

        // DELETE

        public async Task DeleteBicycleAsync(Guid id)
        {
            var bicycle = await _bicycleRepository.GetBicycleByIdAsync(id)
                ?? throw new Exception(ResourceMessagesException.BICYCLE_NOT_FOUND);

            await _bicycleRepository.DeleteAsync(bicycle);
        }

        private static BicycleDTO MapToDTO(Domain.Entity.Bicycle bicycle) => new()
        {
            Name = bicycle.Name,
            Description = bicycle.Description,
            Brand = bicycle.Brand,
            Model = bicycle.Model,
            Color = bicycle.Color,
            Price = bicycle.Price
        };
    }
}
