using EliteThreadsWebApp.Services.ShoppingCart.Business.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.ShoppingCart.Business.Validators
{
    public class CreateUpdateCartCommandValidator : AbstractValidator<CreateUpdateCartCommand>
    {
        public CreateUpdateCartCommandValidator()
        {
            RuleFor(command => command.DTO).NotEmpty();
            RuleFor(command => command.DTO.ProductId).NotEmpty();
            RuleFor(command => command.DTO.UserId).NotEmpty();
            RuleFor(command => command.DTO.SelectedColor).NotEmpty();
            RuleFor(command => command.DTO.SelectedSize).NotEmpty();
            RuleFor(command => command.DTO.Quantity)
                .NotEmpty()
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(5);
        }
    }
}
