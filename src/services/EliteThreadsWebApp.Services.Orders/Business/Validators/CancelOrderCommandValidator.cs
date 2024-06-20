using EliteThreadsWebApp.Services.Orders.Business.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Orders.Business.Validators
{
    public class CancelOrderCommandValidator : AbstractValidator<CancelOrderCommand>
    {
        public CancelOrderCommandValidator()
        {
            RuleFor(command => command.OrderHeaderId).NotEmpty();
        }
    }
}
