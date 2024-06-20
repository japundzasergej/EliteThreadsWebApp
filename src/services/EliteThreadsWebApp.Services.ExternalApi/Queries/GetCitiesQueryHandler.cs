using EliteThreadsWebApp.Services.ExternalApi.DTO;
using EliteThreadsWebApp.Services.ExternalApi.Interfaces;
using MediatR;

namespace EliteThreadsWebApp.Services.ExternalApi.Queries
{
    public class GetCitiesQueryHandler(ICountryCityStateService countryCityStateService)
        : IRequestHandler<GetCitiesQuery, IEnumerable<CityDTO>>
    {
        public Task<IEnumerable<CityDTO>> Handle(
            GetCitiesQuery request,
            CancellationToken cancellationToken
        )
        {
            return countryCityStateService.GetCities(request.State);
        }
    }
}
