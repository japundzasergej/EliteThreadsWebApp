using EliteThreadsWebApp.Services.Social.Business.Reviews.Queries;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Social.Business.Validators.Review.Queries
{
    public class GetRatingByProductIdQueryValidator : AbstractValidator<GetRatingByProductIdQuery>
    {
        public GetRatingByProductIdQueryValidator()
        {
            RuleFor(query => query.ProductId).NotEmpty();
        }
    }
}
