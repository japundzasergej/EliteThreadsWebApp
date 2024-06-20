using EliteThreadsWebApp.Services.ExternalApi.DTO;
using EliteThreadsWebApp.Services.ExternalApi.Interfaces;
using MediatR;

namespace EliteThreadsWebApp.Services.ExternalApi.Queries
{
    public class GetStatesQueryHandler(ICountryCityStateService countryCityStateService)
        : IRequestHandler<GetStatesQuery, IEnumerable<StateDTO>>
    {
        public Task<IEnumerable<StateDTO>> Handle(
            GetStatesQuery request,
            CancellationToken cancellationToken
        )
        {
            return countryCityStateService.GetStates(request.Country);
        }
    }
}
