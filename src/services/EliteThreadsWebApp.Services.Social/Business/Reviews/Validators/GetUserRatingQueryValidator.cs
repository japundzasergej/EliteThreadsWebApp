using EliteThreadsWebApp.Services.Social.Business.Reviews.Queries;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Validators
{
    public class GetUserRatingQueryValidator : AbstractValidator<GetUserRatingQuery>
    {
        public GetUserRatingQueryValidator()
        {
            RuleFor(query => query.ProductId).NotEmpty();
        }
    }
}
