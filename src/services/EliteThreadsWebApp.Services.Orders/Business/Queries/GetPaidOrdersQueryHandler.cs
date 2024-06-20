using AutoMapper;
using EliteThreadsWebApp.Services.Orders.Business.DTO;
using EliteThreadsWebApp.Services.Orders.Infrastructure.Repository;
using MediatR;

namespace EliteThreadsWebApp.Services.Orders.Business.Queries
{
    public class GetPaidOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        : IRequestHandler<GetPaidOrdersQuery, PaginatedOrderListDTO>
    {
        public async Task<PaginatedOrderListDTO> Handle(
            GetPaidOrdersQuery request,
            CancellationToken cancellationToken
        )
        {
            var paginatedList = mapper.Map<PaginatedOrderListDTO>(
                await orderRepository.GetPaidOrdersAsync(request.Page)
            );
            if (paginatedList.TotalCount == 0)
            {
                return new PaginatedOrderListDTO
                {
                    Items =  [ ],
                    TotalCount = 0,
                    TotalPages = 0,
                };
            }

            return paginatedList;
        }
    }
}
