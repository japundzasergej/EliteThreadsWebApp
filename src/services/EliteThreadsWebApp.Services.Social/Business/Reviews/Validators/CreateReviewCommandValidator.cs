using EliteThreadsWebApp.Services.Social.Business.Reviews.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Social.Business.Validators.Review.Commands
{
    public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewCommandValidator()
        {
            RuleFor(command => command.ProductId).NotEmpty();
            RuleFor(command => command.ReviewsDTO).NotEmpty();
            RuleFor(command => command.ReviewsDTO.Title)
                .MinimumLength(5)
                .MaximumLength(15)
                .NotEmpty();
            RuleFor(command => command.ReviewsDTO.Description)
                .MinimumLength(10)
                .MaximumLength(100)
                .NotEmpty();
            RuleFor(command => command.ReviewsDTO.UserId).NotEmpty();
        }
    }
}
