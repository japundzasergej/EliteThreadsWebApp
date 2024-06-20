using MediatR;

namespace EliteThreadsWebApp.Services.Orders.Business.Commands
{
    public class CancelOrderCommand : IRequest<bool>
    {
        public string OrderHeaderId { get; init; }
    }
}
