using AutoMapper;
using EliteThreadsWebApp.Services.Promotions.Business.DTO;
using EliteThreadsWebApp.Services.Promotions.Infrastructure.Repository;
using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Queries
{
    public class GetCollectionsQueryHandler(
        IPromotionsRepository promotionsRepository,
        IMapper mapper
    ) : IRequestHandler<GetCollectionsQuery, IEnumerable<CollectionsDTO>>
    {
        public async Task<IEnumerable<CollectionsDTO>> Handle(
            GetCollectionsQuery request,
            CancellationToken cancellationToken
        )
        {
            var result = await promotionsRepository.GetCollectionsAsync();
            if (!result.Any())
            {
                return [ ];
            }
            return result.Select(mapper.Map<CollectionsDTO>);
        }
    }
}
