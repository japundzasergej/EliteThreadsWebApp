using EliteThreadsWebApp.Services.Orders.Business.DTO;
using MediatR;

namespace EliteThreadsWebApp.Services.Orders.Business.Queries
{
    public class GetPaidOrdersQuery : IRequest<PaginatedOrderListDTO>
    {
        public int? Page { get; init; }
    }
}
