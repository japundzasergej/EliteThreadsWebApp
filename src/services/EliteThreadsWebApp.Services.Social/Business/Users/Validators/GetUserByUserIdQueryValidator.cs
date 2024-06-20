using EliteThreadsWebApp.Services.Social.Business.Users.Queries;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Social.Business.Users.Validators
{
    public class GetUserByUserIdQueryValidator : AbstractValidator<GetUserByUserIdQuery>
    {
        public GetUserByUserIdQueryValidator()
        {
            RuleFor(query => query.UserId).NotEmpty();
        }
    }
}
