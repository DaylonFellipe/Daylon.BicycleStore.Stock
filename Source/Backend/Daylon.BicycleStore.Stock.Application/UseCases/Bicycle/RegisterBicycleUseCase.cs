using Daylon.BicycleStore.Communication.Request;
using Daylon.BicycleStore.Stock.Domain.Entity.Enum;
using Daylon.BicycleStore.Stock.Domain.Repositories.Bicycle;
using Daylon.BicycleStore.Stock.Exceptions;

namespace Daylon.BicycleStore.Stock.Application.UseCases.Bicycle
{
    public class RegisterBicycleUseCase : IRegisterBicycleUseCase
    {
        private readonly IBicycleRepository _bicycleRepository;

        public RegisterBicycleUseCase(IBicycleRepository bicycleRepository)
        {
            _bicycleRepository = bicycleRepository;
        }

        public async Task<Domain.Entity.Bicycle> ExecuteRegisterBicycleAsync(RequestRegisterBicycleJson request)
        {
            // Validate
            ValidateRegister(request);

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
                Status = request.Quantity > 0 ? true : false
            };

            // Save
            await _bicycleRepository.AddAsync(bicycle);
            await _bicycleRepository.SaveChangesAsync();

            return bicycle;
        }

        public async Task<Domain.Entity.Bicycle> ExecuteUpdateBicycleAsync(RequestUpdateBicycleJson request)
        {
            ValidateUpdate(request);


            var bicycle = await _bicycleRepository.GetBicycleByIdAsync(request.Id);

            if (!string.IsNullOrEmpty(request.Name)) bicycle.Name = request.Name;
            if (request.Description != null) bicycle.Description = request.Description;
            if (Enum.IsDefined(typeof(BrandEnum), request.Brand)) bicycle.Brand = request.Brand;
            if (Enum.IsDefined(typeof(ModelEnum), request.Model)) bicycle.Model = request.Model;
            if (Enum.IsDefined(typeof(ColorEnum), request.Color)) bicycle.Color = request.Color;
            if (request.Price != null) bicycle.Price = request.Price;

            await _bicycleRepository.UpdateTaskAsync(bicycle);
            await _bicycleRepository.SaveChangesAsync();

            return bicycle;
        }

        private static void ValidateRegister(RequestRegisterBicycleJson request)
        {
            var validator = new RegisterBicycleValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage);
                throw new Exception(ResourceMessagesException.INVALID_REQUEST);
            }
        } 
        
        private static void ValidateUpdate(RequestUpdateBicycleJson request)
        {
            var validator = new UpdateBicycleValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage);
                throw new Exception(ResourceMessagesException.INVALID_REQUEST);
            }
        }
    }
}
