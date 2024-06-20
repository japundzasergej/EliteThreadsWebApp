using FluentValidation;

namespace EliteThreadsWebApp.Services.ExternalApi.Commands
{
    public class UploadPhotoCommandValidator : AbstractValidator<UploadPhotoCommand>
    {
        public UploadPhotoCommandValidator()
        {
            RuleFor(command => command.ImagesDTO).NotEmpty();
            RuleFor(command => command.ImagesDTO.ContentType).NotEmpty();
        }
    }
}
