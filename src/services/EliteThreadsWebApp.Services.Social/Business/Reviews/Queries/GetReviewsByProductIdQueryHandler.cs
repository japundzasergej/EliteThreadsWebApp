using AutoMapper;
using EliteThreadsWebApp.Services.Social.Business.DTO.Reviews;
using EliteThreadsWebApp.Services.Social.Infrastructure.Interface;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Queries
{
    public class GetReviewsByProductIdQueryHandler(
        IReviewRepository reviewRepository,
        IMapper mapper
    ) : IRequestHandler<GetReviewsByProductIdQuery, List<ReviewsDTO>>
    {
        public async Task<List<ReviewsDTO>> Handle(
            GetReviewsByProductIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var reviewList =
                await reviewRepository.GetReviewsAsync((int)request.ProductId)
                ?? throw new InvalidDataException("Object doesn't exist");
            ;
            return reviewList.Select(mapper.Map<ReviewsDTO>).ToList();
        }
    }
}
