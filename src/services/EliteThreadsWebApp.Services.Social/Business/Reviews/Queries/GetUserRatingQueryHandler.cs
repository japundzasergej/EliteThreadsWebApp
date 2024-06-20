using AutoMapper;
using EliteThreadsWebApp.Services.Social.Business.DTO.Reviews;
using EliteThreadsWebApp.Services.Social.Infrastructure.Interface;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Queries
{
    public class GetUserRatingQueryHandler(IReviewRepository reviewRepository, IMapper mapper)
        : IRequestHandler<GetUserRatingQuery, UserRatingDTO?>
    {
        public async Task<UserRatingDTO?> Handle(
            GetUserRatingQuery request,
            CancellationToken cancellationToken
        )
        {
            var userRating = await reviewRepository.GetUserRatingAsync(
                request.ProductId,
                request.UserId
            );
            if (userRating != null)
            {
                return mapper.Map<UserRatingDTO>(userRating);
            }
            else
            {
                return null;
            }
        }
    }
}
