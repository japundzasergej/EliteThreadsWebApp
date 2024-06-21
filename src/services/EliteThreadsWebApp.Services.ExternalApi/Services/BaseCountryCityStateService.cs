using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace EliteThreadsWebApp.Services.ExternalApi.Services
{
    public class BaseCountryCityStateService(IHttpClientFactory httpClientFactory)
    {
        protected async Task<TBody> SendAsync<TBody>(string path)
        {
            var client = httpClientFactory.CreateClient("CountryCityStateApiClient");
            var builder = new UriBuilder(client.BaseAddress);
            builder.Path += path;
            client.DefaultRequestHeaders.Clear();
            var message = new HttpRequestMessage();
            message.Headers.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                await GetAccessToken()
            );
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            message.Method = HttpMethod.Get;
            message.RequestUri = builder.Uri;
            var response = await client.SendAsync(message);
            response.EnsureSuccessStatusCode();
            var content =
                await response.Content.ReadAsStringAsync()
                ?? throw new InvalidDataException("Object doesn't exist");
            return System.Text.Json.JsonSerializer.Deserialize<TBody>(content);
        }

        private async Task<string> GetAccessToken()
        {
            var client = httpClientFactory.CreateClient("CountryCityStateApiClient");
            var builder = new UriBuilder(client.BaseAddress);
            builder.Path += "/getaccesstoken";
            var response = await client.GetAsync(builder.Uri);
            var content = await response.Content.ReadAsStringAsync();
            var json = System.Text.Json.JsonSerializer.Deserialize<AuthTokenResponse>(content);
            return json.AuthToken;
        }
    }

    public record AuthTokenResponse
    {
        [JsonPropertyName("auth_token")]
        public string AuthToken { get; init; }
    }
}
