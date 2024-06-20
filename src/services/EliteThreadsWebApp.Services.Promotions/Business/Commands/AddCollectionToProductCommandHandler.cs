using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Promotions.Infrastructure.Repository;
using MassTransit;
using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Commands
{
    public class AddCollectionToProductCommandHandler(
        IPromotionsRepository promotionsRepository,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<AddCollectionToProductCommand, bool>
    {
        public async Task<bool> Handle(
            AddCollectionToProductCommand request,
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
                throw new InvalidDataException("Object doesn't exist.");
            }
            var result = await promotionsRepository.AddCollectionToProductAsync(
                (int)request.CollectionId,
                (int)request.ProductId
            );
            if (result)
            {
                var product =
                    await promotionsRepository.GetPromotionsByProductIdAsync((int)request.ProductId)
                    ?? throw new InvalidDataException("Object doesn't exist");
                await publishEndpoint.Publish(
                    new CollectionChangedEvent
                    {
                        ProductId = product.ProductId,
                        CollectionId = product.CollectionId,
                        CollectionName = product.Collections.CollectionName
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
