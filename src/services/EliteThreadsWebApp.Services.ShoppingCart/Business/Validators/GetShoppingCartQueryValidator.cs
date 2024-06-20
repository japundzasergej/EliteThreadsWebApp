using EliteThreadsWebApp.Services.ShoppingCart.Business.Queries;
using FluentValidation;

namespace EliteThreadsWebApp.Services.ShoppingCart.Business.Validators
{
    public class GetShoppingCartQueryValidator : AbstractValidator<GetShoppingCartQuery>
    {
        public GetShoppingCartQueryValidator()
        {
            RuleFor(query => query.UserId).NotEmpty();
        }
    }
}
