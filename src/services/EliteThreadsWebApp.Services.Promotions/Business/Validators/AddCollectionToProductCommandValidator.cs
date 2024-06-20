using EliteThreadsWebApp.Services.Promotions.Business.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Promotions.Business.Validators
{
    public class AddCollectionToProductCommandValidator
        : AbstractValidator<AddCollectionToProductCommand>
    {
        public AddCollectionToProductCommandValidator()
        {
            RuleFor(command => command.ProductId).NotEmpty();
            RuleFor(command => command.CollectionId).NotEmpty();
        }
    }
}
