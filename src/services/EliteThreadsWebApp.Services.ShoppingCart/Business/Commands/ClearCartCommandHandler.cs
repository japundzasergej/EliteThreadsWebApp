using EliteThreadsWebApp.Services.ShoppingCart.Infrastructure.Repository;
using MediatR;

namespace EliteThreadsWebApp.Services.ShoppingCart.Business.Commands
{
    public class ClearCartCommandHandler(IShoppingCartRepository shoppingCartRepository)
        : IRequestHandler<ClearCartCommand, bool>
    {
        public async Task<bool> Handle(
            ClearCartCommand request,
            CancellationToken cancellationToken
        )
        {
            return await shoppingCartRepository.ClearCartAsync(request.UserId);
        }
    }
}
