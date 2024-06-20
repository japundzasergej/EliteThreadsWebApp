using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Commands
{
    public class AddCollectionToProductCommand : IRequest<bool>
    {
        public int? ProductId { get; init; }
        public int? CollectionId { get; init; }
    }
}
