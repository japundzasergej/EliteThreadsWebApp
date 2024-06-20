using EliteThreadsWebApp.Services.Products.Business.DTO;
using MediatR;

namespace EliteThreadsWebApp.Services.Products.Business.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDTO>
    {
        public int? ProductId { get; set; }
    }
}
