using Auth0.ManagementApi;
using EliteThreadsWebApp.Services.Social.Business.Helpers;
using EliteThreadsWebApp.Services.Social.Business.Interfaces;
using Microsoft.Extensions.Options;

namespace EliteThreadsWebApp.Services.Social.Business.Services
{
    public class Auth0ManagementService : IAuth0ManagementService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<Auth0Settings> _auth0Settings;

        public Auth0ManagementService(
            IHttpClientFactory httpClientFactory,
            IOptions<Auth0Settings> auth0Settings
        )
        {
            _httpClientFactory = httpClientFactory;
            _auth0Settings = auth0Settings;
        }

        public async Task<ManagementApiClient> GetManagementApiClient()
        {
            var accessToken = await GetAccessToken();
            var domain = new Uri($"https://{_auth0Settings.Value.Domain}/api/v2/");

            return new ManagementApiClient(accessToken, domain);
        }

        private async Task<string> GetAccessToken()
        {
            var client = _httpClientFactory.CreateClient("Auth0ApiClient");
            var requestData = new
            {
                client_id = _auth0Settings.Value.ClientId,
                client_secret = _auth0Settings.Value.ClientSecret,
                audience = _auth0Settings.Value.Audience,
                grant_type = "client_credentials"
            };

            var response = await client.PostAsJsonAsync("/oauth/token", requestData);
            response.EnsureSuccessStatusCode();

            var tokenResponse = await response.Content.ReadFromJsonAsync<Auth0TokenResponse>();
            return tokenResponse.AccessToken;
        }
    }
}
