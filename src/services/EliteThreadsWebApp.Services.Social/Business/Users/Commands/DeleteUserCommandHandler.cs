using EliteThreadsWebApp.Services.Social.Business.Interfaces;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Users.Commands
{
    public class DeleteUserCommandHandler(IAuth0ManagementService auth0ManagementService)
        : IRequestHandler<DeleteUserCommand, bool>
    {
        public async Task<bool> Handle(
            DeleteUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var client = await auth0ManagementService.GetManagementApiClient();
            await client.Users.DeleteAsync(request.UserId);
            return true;
        }
    }
}
