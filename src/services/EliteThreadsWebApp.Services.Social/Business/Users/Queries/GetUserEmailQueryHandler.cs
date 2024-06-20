using EliteThreadsWebApp.Services.Social.Business.DTO.User;
using EliteThreadsWebApp.Services.Social.Business.Interfaces;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Users.Queries
{
    public class GetUserEmailQueryHandler(IAuth0ManagementService auth0ManagementService)
        : IRequestHandler<GetUserEmailQuery, UserEmailDTO>
    {
        public async Task<UserEmailDTO> Handle(
            GetUserEmailQuery request,
            CancellationToken cancellationToken
        )
        {
            var client = await auth0ManagementService.GetManagementApiClient();

            var user = await client.Users.GetAsync(request.UserId);
            return new UserEmailDTO()
            {
                UserEmail = user.Email,
                FullName = user.UserMetadata.FirstName + user.UserMetadata.LastName
            };
        }
    }
}
