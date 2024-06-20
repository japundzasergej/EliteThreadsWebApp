using EliteThreadsWebApp.Services.Products.Business.DTO.Products;
using MediatR;

namespace EliteThreadsWebApp.Services.Products.Business.Commands
{
    public class CreateProductCommand : IRequest<bool>
    {
        public CreateProductDTO ProductDTO { get; set; }
    }
}
