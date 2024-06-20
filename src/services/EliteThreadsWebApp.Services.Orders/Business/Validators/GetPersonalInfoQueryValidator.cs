using EliteThreadsWebApp.Services.Orders.Business.Queries;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Orders.Business.Validators
{
    public class GetPersonalInfoQueryValidator : AbstractValidator<GetPersonalInfoQuery>
    {
        public GetPersonalInfoQueryValidator()
        {
            RuleFor(query => query.UserId).NotEmpty();
        }
    }
}
