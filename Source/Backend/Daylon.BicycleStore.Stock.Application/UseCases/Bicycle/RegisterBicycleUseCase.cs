using Daylon.BicycleStore.Communication.Request;
using Daylon.BicycleStore.Stock.Domain.Repositories.Bicycle;

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
            Validate(request);



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

        private static void Validate(RequestRegisterBicycleJson request)
        {
            var validator = new RegisterBicycleValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage);
                throw new Exception("Request is not valid");
            }
        }
    }
}
