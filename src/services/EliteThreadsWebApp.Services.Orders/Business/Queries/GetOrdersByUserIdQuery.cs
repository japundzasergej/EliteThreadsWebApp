using EliteThreadsWebApp.Services.Orders.Business.DTO;
using MediatR;

namespace EliteThreadsWebApp.Services.Orders.Business.Queries
{
    public class GetOrdersByUserIdQuery : IRequest<PaginatedOrderListDTO>
    {
        public string UserId { get; init; }
        public int? Page { get; init; }
    }
}
