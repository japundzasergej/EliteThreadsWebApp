using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Users.Queries
{
    public class GetWishlistByUserIdQuery : IRequest<List<int>>
    {
        public string UserId { get; init; }
    }
}
