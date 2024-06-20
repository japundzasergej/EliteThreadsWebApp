using EliteThreadsWebApp.Services.Social.Business.DTO.Reviews;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Queries
{
    public class GetUserRatingQuery : IRequest<UserRatingDTO>
    {
        public int ProductId { get; init; }
        public string? UserId { get; init; }
    }
}
