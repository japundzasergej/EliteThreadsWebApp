using EliteThreadsWebApp.Services.Social.Infrastructure.Interface;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Users.Commands
{
    public class AddProductToWishlistCommandHandler(IUserWishlistRepository userWishlistRepository)
        : IRequestHandler<AddProductToWishlistCommand, bool>
    {
        public async Task<bool> Handle(
            AddProductToWishlistCommand request,
            CancellationToken cancellationToken
        )
        {
            return await userWishlistRepository.AddProductToWishlistAsync(
                request.UserId,
                request.ProductId
            );
        }
    }
}
