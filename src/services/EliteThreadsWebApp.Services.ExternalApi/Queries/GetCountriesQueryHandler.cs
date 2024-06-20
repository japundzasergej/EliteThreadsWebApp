using EliteThreadsWebApp.Services.ExternalApi.DTO;
using EliteThreadsWebApp.Services.ExternalApi.Interfaces;
using MediatR;

namespace EliteThreadsWebApp.Services.ExternalApi.Queries
{
    public class GetCountriesQueryHandler(ICountryCityStateService countryCityStateService)
        : IRequestHandler<GetCountriesQuery, IEnumerable<CountryDTO>>
    {
        public Task<IEnumerable<CountryDTO>> Handle(
            GetCountriesQuery request,
            CancellationToken cancellationToken
        )
        {
            return countryCityStateService.GetCountries();
        }
    }
}
