using EliteThreadsWebApp.Services.ExternalApi.DTO;

namespace EliteThreadsWebApp.Services.ExternalApi.Interfaces
{
    public interface IGeolocationService
    {
        Task<GeolocationDTO> GetGeolocation();
    }
}
