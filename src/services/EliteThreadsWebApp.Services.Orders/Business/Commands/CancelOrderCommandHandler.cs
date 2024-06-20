using EliteThreadsWebApp.Services.Orders.Infrastructure.Repository;
using MediatR;

namespace EliteThreadsWebApp.Services.Orders.Business.Commands
{
    public class CancelOrderCommandHandler(IOrderRepository orderRepository)
        : IRequestHandler<CancelOrderCommand, bool>
    {
        public async Task<bool> Handle(
            CancelOrderCommand request,
            CancellationToken cancellationToken
        )
        {
            return await orderRepository.CancelOrderAsync(request.OrderHeaderId);
        }
    }
}
