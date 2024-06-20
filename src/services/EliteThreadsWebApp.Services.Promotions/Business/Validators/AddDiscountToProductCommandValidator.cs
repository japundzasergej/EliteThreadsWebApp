using EliteThreadsWebApp.Services.Promotions.Business.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Promotions.Business.Validators
{
    public class AddDiscountToProductCommandValidator
        : AbstractValidator<AddDiscountToProductCommand>
    {
        public AddDiscountToProductCommandValidator()
        {
            RuleFor(command => command.ProductId).NotEmpty();
            RuleFor(command => command.DiscountId).NotEmpty();
        }
    }
}
