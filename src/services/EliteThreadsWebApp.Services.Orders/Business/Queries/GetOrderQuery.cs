using EliteThreadsWebApp.Services.Orders.Business.DTO;
using MediatR;

namespace EliteThreadsWebApp.Services.Orders.Business.Queries
{
    public class GetOrderQuery : IRequest<OrderDTO>
    {
        public string OrderHeaderId { get; init; }
    }
}
