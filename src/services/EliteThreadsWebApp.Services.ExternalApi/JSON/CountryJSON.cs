using System.Text.Json.Serialization;

namespace EliteThreadsWebApp.Services.ExternalApi.JSON
{
    public class CountryJSON
    {
        [JsonPropertyName("country_name")]
        public string CountryName { get; init; }

        [JsonPropertyName("country_short_name")]
        public string CountryShortName { get; init; }
    }
}
