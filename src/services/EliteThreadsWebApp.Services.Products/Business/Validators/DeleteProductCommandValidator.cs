using EliteThreadsWebApp.Services.Products.Business.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Products.Business.Validators
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(command => command.ProductId).NotEmpty();
        }
    }
}
