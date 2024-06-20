using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Commands
{
    public class AddDiscountToProductCommand : IRequest<bool>
    {
        public int? DiscountId { get; init; }
        public int? ProductId { get; init; }
    }
}
