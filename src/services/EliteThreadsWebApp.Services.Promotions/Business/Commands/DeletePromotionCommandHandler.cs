using EliteThreadsWebApp.Services.Promotions.Infrastructure.Repository;
using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Commands
{
    public class DeletePromotionCommandHandler(IPromotionsRepository promotionsRepository)
        : IRequestHandler<DeletePromotionCommand, bool>
    {
        public async Task<bool> Handle(
            DeletePromotionCommand request,
            CancellationToken cancellationToken
        )
        {
            return await promotionsRepository.DeletePromotionAsync(request.PromotionId);
        }
    }
}
