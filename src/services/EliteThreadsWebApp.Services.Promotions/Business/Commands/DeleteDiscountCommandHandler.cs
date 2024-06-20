using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Promotions.Infrastructure.Repository;
using MassTransit;
using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Commands
{
    public class DeleteDiscountCommandHandler(
        IPromotionsRepository promotionsRepository,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<DeleteDiscountCommand, bool>
    {
        public async Task<bool> Handle(
            DeleteDiscountCommand request,
            CancellationToken cancellationToken
        )
        {
            if (request.DiscountId == null || request.DiscountId == 0)
            {
                throw new InvalidDataException("Object doesn't exist");
            }
            var deletionResult = await promotionsRepository.DeleteDiscountAsync(
                (int)request.DiscountId
            );
            if (deletionResult.IsSuccessful)
            {
                await publishEndpoint.Publish(
                    new DiscountDeletedEvent { ProductIds = deletionResult.ProductIds.ToList(), },
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
