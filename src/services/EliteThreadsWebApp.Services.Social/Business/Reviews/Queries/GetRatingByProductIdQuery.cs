using EliteThreadsWebApp.Services.Social.Business.DTO.Reviews;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Queries
{
    public class GetRatingByProductIdQuery : IRequest<ProductRatingDTO>
    {
        public int ProductId { get; init; }
    }
}
