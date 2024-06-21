using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Promotions.Infrastructure.Repository;
using MassTransit;
using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Commands
{
    public class AddDiscountToProductCommandHandler(
        IPromotionsRepository promotionsRepository,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<AddDiscountToProductCommand, bool>
    {
        public async Task<bool> Handle(
            AddDiscountToProductCommand request,
            CancellationToken cancellationToken
        )
        {
            if (
                request.ProductId == null
                || request.ProductId == 0
                || request.DiscountId == null
                || request.DiscountId == 0
            )
            {
                throw new InvalidDataException("Object doesn't exist.");
            }
            var result = await promotionsRepository.AddDiscountToProductAsync(
                (int)request.DiscountId,
                (int)request.ProductId
            );
            if (result)
            {
                var product =
                    await promotionsRepository.GetPromotionsByProductIdAsync((int)request.ProductId)
                    ?? throw new InvalidDataException("Object doesn't exist.");
                await publishEndpoint.Publish(
                    new DiscountChangedEvent
                    {
                        ProductId = product.ProductId,
                        DiscountId = product.DiscountId,
                        DiscountAmount = product.Discount.DiscountAmount,
                        DiscountName = product.Discount.DiscountName,
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
