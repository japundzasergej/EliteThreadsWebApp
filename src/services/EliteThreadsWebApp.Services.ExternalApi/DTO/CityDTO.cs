using System.Text.Json.Serialization;

namespace EliteThreadsWebApp.Services.ExternalApi.DTO
{
    public record CityDTO
    {
        [JsonPropertyName("city_name")]
        public string CityName { get; init; }
    }
}
