using EliteThreadsWebApp.Services.ShoppingCart.Infrastructure.Repository;
using MediatR;

namespace EliteThreadsWebApp.Services.ShoppingCart.Business.Commands
{
    public class RemoveFromCartCommandHandler(IShoppingCartRepository shoppingCartRepository)
        : IRequestHandler<RemoveFromCartCommand, bool>
    {
        public async Task<bool> Handle(
            RemoveFromCartCommand request,
            CancellationToken cancellationToken
        )
        {
            return await shoppingCartRepository.RemoveFromCartAsync(request.CartDetailId);
        }
    }
}
