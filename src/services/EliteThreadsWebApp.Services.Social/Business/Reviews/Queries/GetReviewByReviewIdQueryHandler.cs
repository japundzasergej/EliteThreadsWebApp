using AutoMapper;
using EliteThreadsWebApp.Services.Social.Business.DTO.Reviews;
using EliteThreadsWebApp.Services.Social.Business.Helpers;
using EliteThreadsWebApp.Services.Social.Infrastructure.Interface;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Queries
{
    public class GetReviewByReviewIdQueryHandler(IReviewRepository reviewRepository, IMapper mapper)
        : IRequestHandler<GetReviewByReviewIdQuery, ReviewsDTO>
    {
        public async Task<ReviewsDTO> Handle(
            GetReviewByReviewIdQuery request,
            CancellationToken cancellationToken
        )
        {
            return mapper.Map<ReviewsDTO>(
                await reviewRepository.GetReviewByIdAsync(request.ReviewId)
            );
        }
    }
}
