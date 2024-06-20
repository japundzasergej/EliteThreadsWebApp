using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Promotions.Infrastructure.Repository;
using MassTransit;
using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Commands
{
    public class DeleteCollectionCommandHandler(
        IPromotionsRepository promotionsRepository,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<DeleteCollectionCommand, bool>
    {
        public async Task<bool> Handle(
            DeleteCollectionCommand request,
            CancellationToken cancellationToken
        )
        {
            if (request.CollectionId == null || request.CollectionId == 0)
                throw new InvalidDataException("Object doesn't exist");
            var deletionResult = await promotionsRepository.DeleteCollectionAsync(
                (int)request.CollectionId
            );
            if (deletionResult.IsSuccessful)
            {
                await publishEndpoint.Publish(
                    new CollectionDeletedEvent { ProductIds = deletionResult.ProductIds.ToList(), },
                    cancellationToken
                );
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
