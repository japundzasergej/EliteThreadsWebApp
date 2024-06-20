using AutoMapper;
using EliteThreadsWebApp.Services.Products.Domain.Entities;
using EliteThreadsWebApp.Services.Products.Infrastructure.Repository;
using MediatR;

namespace EliteThreadsWebApp.Services.Products.Business.Commands
{
    public class DeleteProductCommandHandler(IProductRepository productRepository)
        : IRequestHandler<DeleteProductCommand, bool>
    {
        public async Task<bool> Handle(
            DeleteProductCommand request,
            CancellationToken cancellationToken
        )
        {
            return await productRepository.DeleteProductAsync(
                await productRepository.GetProductByIdAsync((int)request.ProductId)
                    ?? throw new InvalidDataException("Object doesn't exist.")
            );
        }
    }
}
