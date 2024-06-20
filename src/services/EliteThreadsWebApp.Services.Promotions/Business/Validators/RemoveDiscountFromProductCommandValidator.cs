using EliteThreadsWebApp.Services.Promotions.Business.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Promotions.Business.Validators
{
    public class RemoveDiscountFromProductCommandValidator
        : AbstractValidator<RemoveDiscountFromProductCommand>
    {
        public RemoveDiscountFromProductCommandValidator()
        {
            RuleFor(command => command.ProductId).NotEmpty();
            RuleFor(command => command.DiscountId).NotEmpty();
        }
    }
}
