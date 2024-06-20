using EliteThreadsWebApp.Services.Social.Infrastructure.Interface;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Users.Queries
{
    public class GetWishlistByUserIdQueryHandler(IUserWishlistRepository userWishlistRepository)
        : IRequestHandler<GetWishlistByUserIdQuery, List<int>>
    {
        public async Task<List<int>> Handle(
            GetWishlistByUserIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var wishList = await userWishlistRepository.GetWishlistProductsByUserIdAsync(
                request.UserId
            );
            return wishList.ToList();
        }
    }
}
