using Daylon.BicycleStore.Communication.Request;
using Daylon.BicycleStore.Stock.Domain.Entity.Enum;
using Daylon.BicycleStore.Stock.Domain.Repositories.Bicycle;
using Daylon.BicycleStore.Stock.Exceptions;
using FluentValidation;

namespace Daylon.BicycleStore.Stock.Application.UseCases.Bicycle
{
    public class BicycleUseCase : IBicycleUseCase
    {
        private readonly IBicycleRepository _bicycleRepository;

        public BicycleUseCase(IBicycleRepository bicycleRepository)
        {
            _bicycleRepository = bicycleRepository;
        }

        public async Task<Domain.Entity.Bicycle> ExecuteRegisterBicycleAsync(RequestRegisterBicycleJson request)
        {
            // Validate
            ValidateRequest(request, new RegisterBicycleValidator());

            // Map
            var bicycle = new Domain.Entity.Bicycle
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Brand = request.Brand,
                Model = request.Model,
                Color = request.Color,
                Price = request.Price,
                Quantity = request.Quantity,
                IsAvailable = request.Quantity > 0
            };

            // Save
            await _bicycleRepository.AddAsync(bicycle);

            return bicycle;
        }

        public async Task<Domain.Entity.Bicycle> ExecuteUpdateBicycleAsync(RequestUpdateBicycleJson request)
        {
            // Validate
            ValidateRequest(request, new UpdateBicycleValidator());

            var bicycle = await _bicycleRepository.GetBicycleByIdAsync(request.Id);

            // Map and Update
            if (bicycle != null)
            {
                if (!string.IsNullOrEmpty(request.Name)) bicycle.Name = request.Name;
                bicycle.Description = request.Description;
                if (Enum.IsDefined(typeof(BrandEnum), request.Brand)) bicycle.Brand = request.Brand;
                if (Enum.IsDefined(typeof(ModelEnum), request.Model)) bicycle.Model = request.Model;
                if (Enum.IsDefined(typeof(ColorEnum), request.Color)) bicycle.Color = request.Color;
                bicycle.Price = request.Price;
                bicycle.Quantity = request.Quantity;
                bicycle.IsAvailable = request.Quantity > 0;

                // Save
                await _bicycleRepository.UpdateAsync(bicycle!);
            }

            return bicycle!;
        }

        private static void ValidateRequest<T>(T request, AbstractValidator<T> validator)
        {
            var result = validator.ValidateAsync(request);

            if (!result.Result.IsValid)
            {
                var errors = result.Result.Errors.Select(e => e.ErrorMessage);
                throw new Exception(ResourceMessagesException.INVALID_REQUEST);
            }
        }
    }
}
