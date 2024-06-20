using EliteThreadsWebApp.Services.ExternalApi.DTO;
using MediatR;

namespace EliteThreadsWebApp.Services.ExternalApi.Commands
{
    public class UploadPhotoCommand : IRequest<string>
    {
        public ImagesDTO ImagesDTO { get; set; }
    }
}
