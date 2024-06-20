using Auth0.ManagementApi.Models;
using EliteThreadsWebApp.Services.Social.Business.DTO.User;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Users.Queries
{
    public class GetUserByUserIdQuery : IRequest<UserDTO>
    {
        public string UserId { get; init; }
    }
}
