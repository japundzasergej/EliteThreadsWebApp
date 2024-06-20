using EliteThreadsWebApp.Services.Orders.Business.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Orders.Business.Validators
{
    public class UpdatePersonalInfoCommandValidator : AbstractValidator<UpdatePersonalInfoCommand>
    {
        public UpdatePersonalInfoCommandValidator()
        {
            RuleFor(command => command.DTO).NotEmpty();
        }
    }
}
