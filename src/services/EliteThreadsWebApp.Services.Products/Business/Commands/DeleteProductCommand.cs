using MediatR;

namespace EliteThreadsWebApp.Services.Products.Business.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int? ProductId { get; set; }
    }
}
