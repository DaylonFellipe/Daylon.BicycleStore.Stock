using Daylon.BicycleStore.Communication.Request;
using Daylon.BicycleStore.Stock.Exceptions;
using FluentValidation;

namespace Daylon.BicycleStore.Stock.Application.UseCases.Bicycle
{
    internal static class BicycleValidator{ }
    
    public class RegisterBicycleValidator : AbstractValidator<RequestRegisterBicycleJson>
    {
        public RegisterBicycleValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(n => n.Name)
                .NotEmpty().WithMessage(ResourceMessagesException.EMPTY_NAME);

            RuleFor(b => b.Brand)
                .IsInEnum().WithMessage(ResourceMessagesException.REQUIRED_BRAND);

            RuleFor(m => m.Model)
                .IsInEnum().WithMessage(ResourceMessagesException.REQUIRED_MODEL);

            RuleFor(c => c.Color)
                .IsInEnum().WithMessage(ResourceMessagesException.REQUIRED_COLOR);

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage(ResourceMessagesException.EMPTY_PRICE)
                .GreaterThan(0).WithMessage(ResourceMessagesException.VALID_VALUE_PRICE);

            RuleFor(q => q.Quantity)
                .NotEmpty().WithMessage(ResourceMessagesException.EMPTY_QUANTITY)
                .GreaterThanOrEqualTo(0).WithMessage(ResourceMessagesException.VALID_VALUE_QUANTITY);
        }
    }

    public class UpdateBicycleValidator : AbstractValidator<RequestUpdateBicycleJson>
    {
        public UpdateBicycleValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(n => n.Name)
                .NotEmpty().WithMessage(ResourceMessagesException.EMPTY_NAME);

            RuleFor(b => b.Brand)
                .IsInEnum().WithMessage(ResourceMessagesException.REQUIRED_BRAND);

            RuleFor(m => m.Model)
                .IsInEnum().WithMessage(ResourceMessagesException.REQUIRED_MODEL);

            RuleFor(c => c.Color)
                .IsInEnum().WithMessage(ResourceMessagesException.REQUIRED_COLOR);

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage(ResourceMessagesException.EMPTY_PRICE)
                .GreaterThan(0).WithMessage(ResourceMessagesException.VALID_VALUE_PRICE);

            RuleFor(q => q.Quantity)
                .NotEmpty().WithMessage(ResourceMessagesException.EMPTY_QUANTITY)
                .GreaterThanOrEqualTo(0).WithMessage(ResourceMessagesException.VALID_VALUE_QUANTITY);
        }
    }
}
