using AutoMapper;
using EliteThreadsWebApp.Services.Products.Business.DTO;
using EliteThreadsWebApp.Services.Products.Infrastructure;
using EliteThreadsWebApp.Services.Products.Infrastructure.Repository;
using MediatR;

namespace EliteThreadsWebApp.Services.Products.Business.Queries
{
    public class GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        : IRequestHandler<GetProductsQuery, PaginatedListDTO>
    {
        public async Task<PaginatedListDTO> Handle(
            GetProductsQuery request,
            CancellationToken cancellationToken
        )
        {
            var paginatedList = await productRepository.GetProductsAsync(
                mapper.Map<QueryObject>(request.QueryObject)
            );
            if (paginatedList.TotalCount == 0)
            {
                return new PaginatedListDTO
                {
                    Items =  [ ],
                    TotalCount = 0,
                    TotalPages = 0,
                };
            }

            return mapper.Map<PaginatedListDTO>(paginatedList);
        }
    }
}
