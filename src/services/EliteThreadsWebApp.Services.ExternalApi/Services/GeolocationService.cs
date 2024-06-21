using System.Text.Json;
using EliteThreadsWebApp.Services.ExternalApi.DTO;
using EliteThreadsWebApp.Services.ExternalApi.Interfaces;

namespace EliteThreadsWebApp.Services.ExternalApi.Services
{
    public class GeolocationService(IHttpClientFactory httpClientFactory) : IGeolocationService
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions =
            new() { PropertyNameCaseInsensitive = true };

        public async Task<GeolocationDTO> GetGeolocation()
        {
            var ip = await GetIp();
            var client = httpClientFactory.CreateClient("GeolocationApiClient");
            var builder = new UriBuilder(client.BaseAddress);
            builder.Path += $"/{ip}";

            var response = await client.GetAsync(builder.Uri);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var geolocation =
                JsonSerializer.Deserialize<Geolocation>(content, options: _jsonSerializerOptions)
                ?? throw new InvalidDataException("Object doesn't exist");

            return new GeolocationDTO
            {
                Country = geolocation.Country,
                Flag = $"https://flagsapi.com/{geolocation.CountryCode}/flat/32.png"
            };
        }

        private async Task<string> GetIp()
        {
            var client = httpClientFactory.CreateClient("IpApiClient");
            var response = await client.GetAsync(client.BaseAddress);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public record Geolocation
        {
            public string Country { get; init; }
            public string CountryCode { get; init; }
        }
    }
}
