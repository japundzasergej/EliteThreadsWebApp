using EliteThreadsWebApp.Services.Products.Business.DTO;
using MediatR;

namespace EliteThreadsWebApp.Services.Products.Business.Queries
{
    public class GetUserWishlistQuery : IRequest<IEnumerable<ProductDTO>>
    {
        public string UserId { get; init; }
    }
}
