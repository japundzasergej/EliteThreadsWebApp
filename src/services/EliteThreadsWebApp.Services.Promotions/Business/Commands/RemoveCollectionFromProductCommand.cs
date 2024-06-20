using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Commands
{
    public class RemoveCollectionFromProductCommand : IRequest<bool>
    {
        public int? ProductId { get; init; }
        public int? CollectionId { get; init; }
    }
}
