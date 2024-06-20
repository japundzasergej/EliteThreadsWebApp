using EliteThreadsWebApp.Services.Products.Business.Queries;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Products.Business.Validators
{
    public class GetUserWishlistQueryValidator : AbstractValidator<GetUserWishlistQuery>
    {
        public GetUserWishlistQueryValidator()
        {
            RuleFor(query => query.UserId).NotEmpty();
        }
    }
}
