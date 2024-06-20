using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Users.Commands
{
    public class RemoveProductFromWishlistCommand : IRequest<bool>
    {
        public string UserId { get; init; }
        public int ProductId { get; init; }
    }
}
