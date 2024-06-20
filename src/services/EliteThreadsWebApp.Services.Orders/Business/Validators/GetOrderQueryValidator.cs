using EliteThreadsWebApp.Services.Orders.Business.Queries;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Orders.Business.Validators
{
    public class GetOrderQueryValidator : AbstractValidator<GetOrderQuery>
    {
        public GetOrderQueryValidator()
        {
            RuleFor(query => query.OrderHeaderId).NotEmpty();
        }
    }
}
