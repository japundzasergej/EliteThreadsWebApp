using EliteThreadsWebApp.Services.ShoppingCart.Business.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.ShoppingCart.Business.Validators
{
    public class RemoveFromCartCommandValidator : AbstractValidator<RemoveFromCartCommand>
    {
        public RemoveFromCartCommandValidator()
        {
            RuleFor(command => command.CartDetailId).NotEmpty();
        }
    }
}
