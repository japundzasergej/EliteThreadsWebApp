using EliteThreadsWebApp.Services.ShoppingCart.Business.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.ShoppingCart.Business.Validators
{
    public class CheckoutCartCommandValidator : AbstractValidator<CheckoutCartCommand>
    {
        public CheckoutCartCommandValidator()
        {
            RuleFor(command => command.DTO).NotEmpty();
            RuleFor(command => command.DTO.TotalPrice).NotEmpty();
            RuleFor(command => command.DTO.CartDTO.CartDetails).NotEmpty();
            RuleFor(command => command.DTO.CartDTO.CartHeader).NotEmpty();
        }
    }
}
