using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Promotions.Infrastructure.Repository;
using MassTransit;
using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Commands
{
    public class RemoveCollectionFromProductCommandHandler(
        IPromotionsRepository promotionsRepository,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<RemoveCollectionFromProductCommand, bool>
    {
        public async Task<bool> Handle(
            RemoveCollectionFromProductCommand request,
            CancellationToken cancellationToken
        )
        {
            if (
                request.CollectionId == null
                || request.CollectionId == 0
                || request.ProductId == null
                || request.ProductId == 0
            )
            {
                throw new InvalidDataException("Object doesn't exist");
            }
            var result = await promotionsRepository.RemoveCollectionFromProductAsync(
                (int)request.ProductId,
                (int)request.CollectionId
            );
            if (result)
            {
                var product =
                    await promotionsRepository.GetPromotionsByProductIdAsync((int)request.ProductId)
                    ?? throw new InvalidDataException("Object doesn't exist.");
                await publishEndpoint.Publish(
                    new CollectionChangedEvent
                    {
                        ProductId = product.ProductId,
                        CollectionId = null,
                        CollectionName = null
                    },
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
