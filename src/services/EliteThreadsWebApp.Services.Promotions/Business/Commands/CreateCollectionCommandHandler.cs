using AutoMapper;
using EliteThreadsWebApp.Services.Products.Domain.Entities;
using EliteThreadsWebApp.Services.Promotions.Infrastructure.Repository;
using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Commands
{
    public class CreateCollectionCommandHandler(
        IPromotionsRepository promotionsRepository,
        IMapper mapper
    ) : IRequestHandler<CreateCollectionCommand, bool>
    {
        public async Task<bool> Handle(
            CreateCollectionCommand request,
            CancellationToken cancellationToken
        )
        {
            return await promotionsRepository.CreateCollectionsAsync(
                mapper.Map<Collections>(request.CollectionsDTO)
            );
        }
    }
}
