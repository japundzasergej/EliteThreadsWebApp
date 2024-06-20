using EliteThreadsWebApp.Services.Promotions.Business.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Promotions.Business.Validators
{
    public class DeleteDiscountCommandValidator : AbstractValidator<DeleteDiscountCommand>
    {
        public DeleteDiscountCommandValidator()
        {
            RuleFor(command => command.DiscountId).NotEmpty();
        }
    }
}
