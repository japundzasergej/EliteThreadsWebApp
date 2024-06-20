using EliteThreadsWebApp.Services.Orders.Business.Queries;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Orders.Business.Validators
{
    public class GetOrdersByUserIdQueryValidator : AbstractValidator<GetOrdersByUserIdQuery>
    {
        public GetOrdersByUserIdQueryValidator()
        {
            RuleFor(query => query.UserId).NotEmpty();
        }
    }
}
