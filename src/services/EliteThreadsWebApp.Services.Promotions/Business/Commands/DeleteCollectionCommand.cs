using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Commands
{
    public class DeleteCollectionCommand : IRequest<bool>
    {
        public int? CollectionId { get; init; }
    }
}
