using AutoMapper;
using EliteThreadsWebApp.Services.Orders.Business.DTO;
using EliteThreadsWebApp.Services.Orders.Infrastructure.Repository;
using MediatR;

namespace EliteThreadsWebApp.Services.Orders.Business.Queries
{
    public class GetOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        : IRequestHandler<GetOrderQuery, OrderDTO>
    {
        public async Task<OrderDTO> Handle(
            GetOrderQuery request,
            CancellationToken cancellationToken
        )
        {
            return mapper.Map<OrderDTO>(await orderRepository.GetOrderAsync(request.OrderHeaderId));
        }
    }
}
