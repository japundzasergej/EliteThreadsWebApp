using AutoMapper;
using EliteThreadsWebApp.Services.Products.Business.DTO;
using EliteThreadsWebApp.Services.Products.Infrastructure.Repository;
using MediatR;

namespace EliteThreadsWebApp.Services.Products.Business.Queries
{
    public class GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        : IRequestHandler<GetProductByIdQuery, ProductDTO>
    {
        public async Task<ProductDTO> Handle(
            GetProductByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var product =
                await productRepository.GetProductByIdAsync((int)request.ProductId)
                ?? throw new InvalidDataException("Object doesn't exist");
            return mapper.Map<ProductDTO>(product);
        }
    }
}
