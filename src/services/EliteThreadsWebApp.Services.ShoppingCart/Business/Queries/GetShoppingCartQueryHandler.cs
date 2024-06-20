using AutoMapper;
using EliteThreadsWebApp.Services.ShoppingCart.Business.DTO;
using EliteThreadsWebApp.Services.ShoppingCart.Infrastructure.Repository;
using MediatR;

namespace EliteThreadsWebApp.Services.ShoppingCart.Business.Queries
{
    public class GetShoppingCartQueryHandler(
        IShoppingCartRepository shoppingCartRepository,
        IMapper mapper
    ) : IRequestHandler<GetShoppingCartQuery, CartDTO>
    {
        public async Task<CartDTO> Handle(
            GetShoppingCartQuery request,
            CancellationToken cancellationToken
        )
        {
            var userCart = await shoppingCartRepository.GetCartByUserIdAsync(request.UserId);
            if (userCart.CartHeader is null || userCart.CartDetails is null)
            {
                return new CartDTO();
            }
            return mapper.Map<CartDTO>(userCart);
        }
    }
}
