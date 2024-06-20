using EliteThreadsWebApp.Services.Social.Infrastructure.Interface;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Users.Commands
{
    public class RemoveProductFromWishlistCommandHandler(
        IUserWishlistRepository userWishlistRepository
    ) : IRequestHandler<RemoveProductFromWishlistCommand, bool>
    {
        public async Task<bool> Handle(
            RemoveProductFromWishlistCommand request,
            CancellationToken cancellationToken
        )
        {
            return await userWishlistRepository.RemoveProductFromWishlistAsync(
                request.UserId,
                request.ProductId
            );
        }
    }
}
