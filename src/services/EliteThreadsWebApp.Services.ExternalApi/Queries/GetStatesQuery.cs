using EliteThreadsWebApp.Services.ExternalApi.DTO;
using MediatR;

namespace EliteThreadsWebApp.Services.ExternalApi.Queries
{
    public class GetStatesQuery : IRequest<IEnumerable<StateDTO>>
    {
        public string Country { get; init; }
    }
}
