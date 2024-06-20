using Auth0.ManagementApi.Models;
using AutoMapper;
using EliteThreadsWebApp.Services.Social.Business.Interfaces;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Users.Commands
{
    public class UpdateUserCommandHandler(
        IAuth0ManagementService auth0ManagementService,
        IMapper mapper
    ) : IRequestHandler<UpdateUserCommand, bool>
    {
        public async Task<bool> Handle(
            UpdateUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var client = await auth0ManagementService.GetManagementApiClient();
            var isAuth0Provider = request.UserId?.Split('|')[0] == "auth0";

            if (!isAuth0Provider)
            {
                request.DTO.Picture = null;
            }
            UserUpdateRequest userUpdateRequest = mapper.Map<UserUpdateRequest>(request.DTO);
            await client.Users.UpdateAsync(request.UserId, userUpdateRequest);
            return true;
        }
    }
}
