using AutoMapper;
using EliteThreadsWebApp.Services.Social.Business.DTO.Reviews;
using EliteThreadsWebApp.Services.Social.Infrastructure.Interface;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Queries
{
    public class GetRatingByProductIdQueryHandler(
        IReviewRepository reviewRepository,
        IMapper mapper
    ) : IRequestHandler<GetRatingByProductIdQuery, ProductRatingDTO>
    {
        public async Task<ProductRatingDTO> Handle(
            GetRatingByProductIdQuery request,
            CancellationToken cancellationToken
        )
        {
            return mapper.Map<ProductRatingDTO>(
                await reviewRepository.GetProductRatingsByIdAsync(request.ProductId)
            );
        }
    }
}
