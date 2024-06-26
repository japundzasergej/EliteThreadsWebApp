using EliteThreadsWebApp.Services.Social.Business.Reviews.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Validators
{
    public class AddRatingCommandValidator : AbstractValidator<AddRatingCommand>
    {
        public AddRatingCommandValidator()
        {
            RuleFor(command => command.DTO).NotEmpty();
            RuleFor(command => command.DTO.UserInput).NotEmpty().InclusiveBetween(0.5f, 5f);
            RuleFor(command => command.DTO.UserId).NotEmpty();
        }
    }
}
