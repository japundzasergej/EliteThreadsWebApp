using EliteThreadsWebApp.Services.Products.Business.Queries;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Products.Business.Validators
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(command => command.ProductId).NotEmpty();
        }
    }
}
