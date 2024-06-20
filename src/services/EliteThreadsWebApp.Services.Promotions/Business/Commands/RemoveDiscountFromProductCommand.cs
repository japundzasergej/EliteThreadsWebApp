using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Commands
{
    public class RemoveDiscountFromProductCommand : IRequest<bool>
    {
        public int? ProductId { get; init; }
        public int? DiscountId { get; init; }
    }
}
