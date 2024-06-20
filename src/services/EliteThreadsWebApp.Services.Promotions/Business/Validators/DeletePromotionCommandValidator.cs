using EliteThreadsWebApp.Services.Promotions.Business.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Promotions.Business.Validators
{
    public class DeletePromotionCommandValidator : AbstractValidator<DeletePromotionCommand>
    {
        public DeletePromotionCommandValidator()
        {
            RuleFor(command => command.PromotionId).NotEmpty();
        }
    }
}
