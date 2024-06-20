using EliteThreadsWebApp.Services.ShoppingCart.Business.DTO;
using MediatR;

namespace EliteThreadsWebApp.Services.ShoppingCart.Business.Commands
{
    public class CheckoutCartCommand : IRequest<OrderPlacedDTO>
    {
        public CheckoutDTO DTO { get; init; }
    }
}
