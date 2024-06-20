using EliteThreadsWebApp.Services.ExternalApi.Interfaces;
using FluentValidation;
using MediatR;

namespace EliteThreadsWebApp.Services.ExternalApi.Commands
{
    public class UploadPhotoCommandHandler(
        IPhotoService photoService,
        IValidator<UploadPhotoCommand> validator
    ) : IRequestHandler<UploadPhotoCommand, string>
    {
        public async Task<string> Handle(
            UploadPhotoCommand request,
            CancellationToken cancellationToken
        )
        {
            validator.ValidateAndThrow(request);
            if (request.ImagesDTO.ImageUrl != null)
            {
                await photoService.DeletePhotoAsync(request.ImagesDTO.ImageUrl);
            }
            return await photoService.CloudinaryUpload(
                request.ImagesDTO.imageBytes,
                request.ImagesDTO.ContentType
            );
        }
    }
}
