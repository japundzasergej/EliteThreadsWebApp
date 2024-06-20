using AutoMapper;
using EliteThreadsWebApp.Services.Products.Domain.Entities;
using EliteThreadsWebApp.Services.Products.Infrastructure.Repository;
using MediatR;

namespace EliteThreadsWebApp.Services.Products.Business.Commands
{
    public class CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        : IRequestHandler<CreateProductCommand, bool>
    {
        public async Task<bool> Handle(
            CreateProductCommand request,
            CancellationToken cancellationToken
        )
        {
            return await productRepository.CreateProductAsync(
                mapper.Map<Product>(request.ProductDTO)
            );
        }
    }
}
