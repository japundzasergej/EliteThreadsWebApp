using EliteThreadsWebApp.Services.Social.Business.Reviews.Queries;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Validators
{
    public class GetReviewsByProductIdQueryValidator : AbstractValidator<GetReviewsByProductIdQuery>
    {
        public GetReviewsByProductIdQueryValidator()
        {
            RuleFor(query => query.ProductId).NotEmpty();
        }
    }
}
