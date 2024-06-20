using EliteThreadsWebApp.Services.Social.Business.DTO.User;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Users.Queries
{
    public class GetUserEmailQuery : IRequest<UserEmailDTO>
    {
        public string UserId { get; init; }
    }
}
