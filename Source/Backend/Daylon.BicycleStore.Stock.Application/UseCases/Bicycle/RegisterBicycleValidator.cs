using Daylon.BicycleStore.Communication.Request;
using Daylon.BicycleStore.Stock.Exceptions;
using FluentValidation;

namespace Daylon.BicycleStore.Stock.Application.UseCases.Bicycle
{
    public class RegisterBicycleValidator : AbstractValidator<RequestRegisterBicycleJson>
    {
        public RegisterBicycleValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ResourceMessagesException.EMPTY_NAME);

            RuleFor(x => x.Brand)
                .NotEmpty().WithMessage(ResourceMessagesException.REQUIRED_BRAND);

            RuleFor(x => x.Model)
                .NotEmpty().WithMessage(ResourceMessagesException.REQUIRED_MODEL);

            RuleFor(x => x.Color)
                .NotEmpty().WithMessage(ResourceMessagesException.REQUIRED_COLOR);

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage(ResourceMessagesException.EMPTY_PRICE)
                .GreaterThan(0).WithMessage(ResourceMessagesException.VALID_VALUE_PRICE);

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage(ResourceMessagesException.EMPTY_QUANTITY)
                .GreaterThanOrEqualTo(0).WithMessage(ResourceMessagesException.VALID_VALUE_QUANTITY);
        }
    }

    public class UpdateBicycleValidator : AbstractValidator<RequestUpdateBicycleJson>
    {
        public UpdateBicycleValidator()
        {
            RuleFor(x => x.Name)
                  .NotEmpty().WithMessage(ResourceMessagesException.EMPTY_NAME);

            RuleFor(x => x.Brand)
                .NotEmpty().WithMessage(ResourceMessagesException.REQUIRED_BRAND);

            RuleFor(x => x.Model)
                .NotEmpty().WithMessage(ResourceMessagesException.REQUIRED_MODEL);

            RuleFor(x => x.Color)
                .NotEmpty().WithMessage(ResourceMessagesException.REQUIRED_COLOR);

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage(ResourceMessagesException.EMPTY_PRICE)
                .GreaterThan(0).WithMessage(ResourceMessagesException.VALID_VALUE_PRICE);

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage(ResourceMessagesException.EMPTY_QUANTITY)
                .GreaterThanOrEqualTo(0).WithMessage(ResourceMessagesException.VALID_VALUE_QUANTITY);
        }
    }
}
