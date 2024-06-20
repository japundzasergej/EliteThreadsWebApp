using EliteThreadsWebApp.Services.Promotions.Business.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Promotions.Business.Validators
{
    public class CreatePromotionMessageCommandValidator
        : AbstractValidator<CreatePromotionMessageCommand>
    {
        public CreatePromotionMessageCommandValidator()
        {
            RuleFor(command => command.DTO).NotEmpty();
            RuleFor(command => command.DTO.Message).NotEmpty().MinimumLength(5).MaximumLength(15);
            ;
        }
    }
}
