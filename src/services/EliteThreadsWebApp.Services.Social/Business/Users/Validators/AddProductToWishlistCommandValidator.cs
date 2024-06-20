using EliteThreadsWebApp.Services.Social.Business.Users.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Social.Business.Users.Validators
{
    public class AddProductToWishlistCommandValidator
        : AbstractValidator<AddProductToWishlistCommand>
    {
        public AddProductToWishlistCommandValidator()
        {
            RuleFor(command => command.ProductId).NotEmpty();
            RuleFor(command => command.UserId).NotEmpty();
        }
    }
}
