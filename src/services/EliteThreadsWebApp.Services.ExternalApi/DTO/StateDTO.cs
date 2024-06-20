using System.Text.Json.Serialization;

namespace EliteThreadsWebApp.Services.ExternalApi.DTO
{
    public record StateDTO
    {
        [JsonPropertyName("state_name")]
        public string StateName { get; init; }
    }
}
