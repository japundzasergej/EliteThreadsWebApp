using Auth0.ManagementApi;

namespace EliteThreadsWebApp.Services.Social.Business.Interfaces
{
    public interface IAuth0ManagementService
    {
        Task<ManagementApiClient> GetManagementApiClient();
    }
}
