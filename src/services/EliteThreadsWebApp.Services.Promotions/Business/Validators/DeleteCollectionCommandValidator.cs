using EliteThreadsWebApp.Services.Promotions.Business.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Promotions.Business.Validators
{
    public class DeleteCollectionCommandValidator : AbstractValidator<DeleteCollectionCommand>
    {
        public DeleteCollectionCommandValidator()
        {
            RuleFor(command => command.CollectionId).NotEmpty();
        }
    }
}
