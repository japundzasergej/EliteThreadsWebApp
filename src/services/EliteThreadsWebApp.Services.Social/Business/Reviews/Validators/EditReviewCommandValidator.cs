using EliteThreadsWebApp.Services.Social.Business.Reviews.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Validators
{
    public class EditReviewCommandValidator : AbstractValidator<EditReviewCommand>
    {
        public EditReviewCommandValidator()
        {
            RuleFor(command => command.ReviewsDTO).NotEmpty();
            RuleFor(command => command.ReviewsDTO.Title)
                .MinimumLength(5)
                .MaximumLength(15)
                .NotEmpty();
            RuleFor(command => command.ReviewsDTO.Description)
                .MinimumLength(10)
                .MaximumLength(100)
                .NotEmpty();
        }
    }
}
