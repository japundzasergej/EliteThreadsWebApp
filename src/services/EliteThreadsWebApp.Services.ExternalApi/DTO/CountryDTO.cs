using System.Text.Json.Serialization;

namespace EliteThreadsWebApp.Services.ExternalApi.DTO
{
    public record CountryDTO
    {
        public string CountryName { get; init; }
        public string Flag { get; init; }
    }
}
