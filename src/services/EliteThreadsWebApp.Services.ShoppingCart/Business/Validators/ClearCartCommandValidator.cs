using EliteThreadsWebApp.Services.ShoppingCart.Business.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.ShoppingCart.Business.Validators
{
    public class ClearCartCommandValidator : AbstractValidator<ClearCartCommand>
    {
        public ClearCartCommandValidator()
        {
            RuleFor(command => command.UserId).NotEmpty();
        }
    }
}
