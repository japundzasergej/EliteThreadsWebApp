using AutoMapper;
using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Social.Business.DTO.Reviews;
using EliteThreadsWebApp.Services.Social.Domain.Entities;
using EliteThreadsWebApp.Services.Social.Infrastructure.Interface;
using MassTransit;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Commands
{
    public class AddRatingCommandHandler(
        IReviewRepository reviewRepository,
        IMapper mapper,
        IPublishEndpoint publishEndpoint
    ) : IRequestHandler<AddRatingCommand, bool>
    {
        public async Task<bool> Handle(
            AddRatingCommand request,
            CancellationToken cancellationToken
        )
        {
            var result = await reviewRepository.CreateUserRatingAsync(
                mapper.Map<UserRating>(request.DTO)
            );
            if (result)
            {
                var productFromDb =
                    await reviewRepository.GetProductRatingsByIdAsync(request.DTO.ProductId)
                    ?? throw new InvalidDataException("Object doesn't exist.");
                await publishEndpoint.Publish(
                    new RatingChangedEvent
                    {
                        ProductId = productFromDb.ProductId,
                        Rating = productFromDb.Rating,
                        TotalRatingCount = productFromDb.TotalRatingCount
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
