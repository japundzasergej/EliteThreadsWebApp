using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Commands
{
    public class DeletePromotionCommand : IRequest<bool>
    {
        public int PromotionId { get; init; }
    }
}
