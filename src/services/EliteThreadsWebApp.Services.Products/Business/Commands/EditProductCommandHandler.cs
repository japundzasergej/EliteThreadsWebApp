using System.ComponentModel.DataAnnotations;
using AutoMapper;
using EliteThreadsWebApp.Services.Products.Business.DTO.Products;
using EliteThreadsWebApp.Services.Products.Domain.Entities;
using EliteThreadsWebApp.Services.Products.Infrastructure.Repository;
using FluentValidation;
using MediatR;

namespace EliteThreadsWebApp.Services.Products.Business.Commands
{
    public class EditProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        : IRequestHandler<EditProductCommand, bool>
    {
        public async Task<bool> Handle(
            EditProductCommand request,
            CancellationToken cancellationToken
        )
        {
            var productFromDb =
                await productRepository.GetProductByIdNoTrackAsync((int)request.ProductId)
                ?? throw new InvalidDataException("Object doesn't exist.");

            var updatedProduct = mapper.Map(request.ProductDTO, productFromDb);
            updatedProduct.ProductId = (int)request.ProductId;

            return await productRepository.UpdateProductAsync(updatedProduct);
        }
    }
}
