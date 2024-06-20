using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Users.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public string UserId { get; init; }
    }
}
