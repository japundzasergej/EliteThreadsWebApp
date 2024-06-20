using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Promotions.Infrastructure.Repository;
using MassTransit;
using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Commands
{
    public class RemoveDiscountFromProductCommandHandler(
        IPromotionsRepository promotionsRepository,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<RemoveDiscountFromProductCommand, bool>
    {
        public async Task<bool> Handle(
            RemoveDiscountFromProductCommand request,
            CancellationToken cancellationToken
        )
        {
            if (
                request.DiscountId == null
                || request.DiscountId == 0
                || request.ProductId == null
                || request.ProductId == 0
            )
            {
                throw new InvalidDataException("Object doesn't exist");
            }
            var result = await promotionsRepository.RemoveDiscountFromProductAsync(
                (int)request.ProductId,
                (int)request.DiscountId
            );
            if (result)
            {
                await publishEndpoint.Publish(
                    new DiscountChangedEvent
                    {
                        ProductId = (int)request.ProductId,
                        DiscountId = null,
                        DiscountAmount = null,
                        DiscountName = null
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
