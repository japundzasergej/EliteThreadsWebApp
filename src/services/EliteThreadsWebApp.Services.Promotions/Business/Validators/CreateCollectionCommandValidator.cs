using EliteThreadsWebApp.Services.Promotions.Business.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Promotions.Business.Validators
{
    public class CreateCollectionCommandValidator : AbstractValidator<CreateCollectionCommand>
    {
        public CreateCollectionCommandValidator()
        {
            RuleFor(command => command.CollectionsDTO).NotEmpty();
            RuleFor(command => command.CollectionsDTO.CollectionName)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(15);
        }
    }
}
