using EliteThreadsWebApp.Services.ShoppingCart.Business.DTO;
using MediatR;

namespace EliteThreadsWebApp.Services.ShoppingCart.Business.Commands
{
    public class CreateUpdateCartCommand : IRequest<bool>
    {
        public AddUpdateProductToCartDTO DTO { get; init; }
    }
}
