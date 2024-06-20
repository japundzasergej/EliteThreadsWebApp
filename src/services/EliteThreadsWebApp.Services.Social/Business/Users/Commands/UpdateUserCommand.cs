using EliteThreadsWebApp.Services.Social.Business.DTO.User;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Users.Commands
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public string UserId { get; init; }
        public UserDTO DTO { get; init; }
    }
}
