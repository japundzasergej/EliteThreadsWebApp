using Auth0.ManagementApi.Models;
using EliteThreadsWebApp.Services.Social.Business.Interfaces;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Users.Commands
{
    public class UpdateUserPasswordCommandHandler(
        IAuth0ManagementService auth0ManagementService,
        IConfiguration configuration
    ) : IRequestHandler<UpdateUserPasswordCommand, bool>
    {
        public async Task<bool> Handle(
            UpdateUserPasswordCommand request,
            CancellationToken cancellationToken
        )
        {
            var client = await auth0ManagementService.GetManagementApiClient();
            var connection = await client.Connections.GetAsync(configuration["Auth0:cid"]);
            await client
                .Users
                .UpdateAsync(
                    request.UserId,
                    new UserUpdateRequest
                    {
                        Password = request.DTO.Password,
                        Connection = connection.Name
                    }
                );
            return true;
        }
    }
}
