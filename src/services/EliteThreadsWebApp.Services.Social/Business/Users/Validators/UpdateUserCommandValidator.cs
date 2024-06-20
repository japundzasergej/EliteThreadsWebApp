using EliteThreadsWebApp.Services.Social.Business.Users.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Social.Business.Users.Validators
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(command => command.UserId).NotEmpty();
            RuleFor(command => command.DTO).NotEmpty();
        }
    }
}
