using EliteThreadsWebApp.Services.ExternalApi.DTO;
using MediatR;

namespace EliteThreadsWebApp.Services.ExternalApi.Queries
{
    public class GetCitiesQuery : IRequest<IEnumerable<CityDTO>>
    {
        public string State { get; init; }
    }
}
