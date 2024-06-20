using EliteThreadsWebApp.Services.Social.Business.DTO.User;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Users.Commands
{
    public class UpdateUserPasswordCommand : IRequest<bool>
    {
        public string UserId { get; init; }
        public UpdatePasswordDTO DTO { get; init; }
    }
}
