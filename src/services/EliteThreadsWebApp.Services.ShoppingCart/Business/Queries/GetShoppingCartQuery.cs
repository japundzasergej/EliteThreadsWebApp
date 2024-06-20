using EliteThreadsWebApp.Services.ShoppingCart.Business.DTO;
using MediatR;

namespace EliteThreadsWebApp.Services.ShoppingCart.Business.Queries
{
    public class GetShoppingCartQuery : IRequest<CartDTO>
    {
        public string UserId { get; init; }
    }
}
