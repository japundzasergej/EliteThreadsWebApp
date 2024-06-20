using EliteThreadsWebApp.Services.ExternalApi.DTO;
using EliteThreadsWebApp.Services.ExternalApi.Interfaces;
using MediatR;

namespace EliteThreadsWebApp.Services.ExternalApi.Queries
{
    public class GetUserGeolocationQueryHandler(IGeolocationService geolocationService)
        : IRequestHandler<GetUserGeolocationQuery, GeolocationDTO>
    {
        public async Task<GeolocationDTO> Handle(
            GetUserGeolocationQuery request,
            CancellationToken cancellationToken
        )
        {
            return await geolocationService.GetGeolocation();
        }
    }
}
