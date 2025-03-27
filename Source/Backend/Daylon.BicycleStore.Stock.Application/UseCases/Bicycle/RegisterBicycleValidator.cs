using Daylon.BicycleStore.Communication.Request;
using FluentValidation;

namespace Daylon.BicycleStore.Stock.Application.UseCases.Bicycle
{
    public class RegisterBicycleValidator : AbstractValidator<RequestRegisterBicycleJson>
    {
        public RegisterBicycleValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(x => x.Brand)
                .NotEmpty()
                .WithMessage("Brand is required");

            RuleFor(x => x.Model)
                .NotEmpty()
                .WithMessage("Model is required");

            RuleFor(x => x.Color)
                .NotEmpty()
                .WithMessage("Color is required");

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Price is required");

            RuleFor(x => x.Quantity)
                .GreaterThan(-1).WithMessage("Quantity must be at least 0");
        }
    }
}
