using MediatR;

namespace EliteThreadsWebApp.Services.ShoppingCart.Business.Commands
{
    public class ClearCartCommand : IRequest<bool>
    {
        public string UserId { get; init; }
    }
}
