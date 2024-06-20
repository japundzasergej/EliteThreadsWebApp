using EliteThreadsWebApp.Services.ExternalApi.DTO;
using MediatR;

namespace EliteThreadsWebApp.Services.ExternalApi.Queries
{
    public class GetCountriesQuery : IRequest<IEnumerable<CountryDTO>> { }
}
