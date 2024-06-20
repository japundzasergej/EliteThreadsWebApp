using EliteThreadsWebApp.Services.Promotions.Business.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Promotions.Business.Validators
{
    public class RemoveCollectionFromProductCommandValidator
        : AbstractValidator<RemoveCollectionFromProductCommand>
    {
        public RemoveCollectionFromProductCommandValidator()
        {
            RuleFor(command => command.ProductId).NotEmpty();
            RuleFor(command => command.CollectionId).NotEmpty();
        }
    }
}
