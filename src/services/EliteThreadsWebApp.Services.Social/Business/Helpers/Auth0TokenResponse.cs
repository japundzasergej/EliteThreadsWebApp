using System.Text.Json.Serialization;

namespace EliteThreadsWebApp.Services.Social.Business.Helpers
{
    public record Auth0TokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; init; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; init; }
    }
}
