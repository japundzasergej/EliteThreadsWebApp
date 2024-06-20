using EliteThreadsWebApp.Services.Promotions.Business.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Promotions.Business.Validators
{
    public class CreateDiscountCommandValidator : AbstractValidator<CreateDiscountCommand>
    {
        public CreateDiscountCommandValidator()
        {
            RuleFor(command => command.DiscountDTO).NotEmpty();
            RuleFor(command => command.DiscountDTO.DiscountName)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(15);
            RuleFor(command => command.DiscountDTO.DiscountAmount)
                .NotEmpty()
                .InclusiveBetween(1, 100);
        }
    }
}
