using Azure;
using EliteThreadsWebApp.Services.Products.Business.DTO.Products;
using MediatR;

namespace EliteThreadsWebApp.Services.Products.Business.Commands
{
    public class EditProductCommand : IRequest<bool>
    {
        public int? ProductId { get; set; }
        public EditProductDTO ProductDTO { get; set; }
    }
}
