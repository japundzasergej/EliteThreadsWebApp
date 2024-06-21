using EliteThreadsWebApp.Services.Products.Business.Commands;
using FluentValidation;

namespace EliteThreadsWebApp.Services.Products.Business.Validators
{
    public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
    {
        public EditProductCommandValidator()
        {
            RuleFor(command => command.ProductDTO).NotEmpty();
            RuleFor(command => command.ProductDTO.ProductName)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(15);
            RuleFor(command => command.ProductDTO.ProductDescription)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(150);
            RuleFor(command => command.ProductDTO.ProductsLeft).NotEmpty();
            RuleFor(command => command.ProductDTO.Pattern).NotEmpty();
            RuleFor(command => command.ProductDTO.Color)
                .NotEmpty()
                .WithMessage("Minimum 1 color must be available.");
            RuleFor(command => command.ProductDTO.Fabric).NotEmpty();
            RuleFor(command => command.ProductDTO.ImageList).NotEmpty();
            RuleFor(command => command.ProductDTO.Length).NotEmpty();
            RuleFor(command => command.ProductDTO.Model).NotEmpty();
            RuleFor(command => command.ProductDTO.MustHave).NotNull();
            RuleFor(command => command.ProductDTO.New).NotNull();
            RuleFor(command => command.ProductDTO.Price).NotEmpty();
            RuleFor(command => command.ProductDTO.ProductsLeft).NotEmpty();
            RuleFor(command => command.ProductDTO.Size)
                .NotEmpty()
                .WithMessage("Minimum 1 size must be available.");
            ;
        }
    }
}
