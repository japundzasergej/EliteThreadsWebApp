using EliteThreadsWebApp.Services.Social.Business.Reviews.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Validators
{
    public class DeleteReviewCommandValidator : AbstractValidator<DeleteReviewCommand>
    {
        public DeleteReviewCommandValidator()
        {
            RuleFor(command => command.ReviewId).NotEmpty();
        }
    }
}
