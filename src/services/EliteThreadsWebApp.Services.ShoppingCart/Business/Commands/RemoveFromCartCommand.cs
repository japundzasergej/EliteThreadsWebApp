using MediatR;

namespace EliteThreadsWebApp.Services.ShoppingCart.Business.Commands
{
    public class RemoveFromCartCommand : IRequest<bool>
    {
        public int CartDetailId { get; init; }
    }
}
