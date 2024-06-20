using EliteThreadsWebApp.Services.Social.Business.Users.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Social.Business.Users.Validators
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(command => command.UserId).NotEmpty();
        }
    }
}
