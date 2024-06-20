using EliteThreadsWebApp.Services.Social.Business.Users.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Social.Business.Users.Validators
{
    public class UpdateUserPasswordCommandValidator : AbstractValidator<UpdateUserPasswordCommand>
    {
        public UpdateUserPasswordCommandValidator()
        {
            RuleFor(command => command.DTO.Password).NotEmpty();
        }
    }
}
