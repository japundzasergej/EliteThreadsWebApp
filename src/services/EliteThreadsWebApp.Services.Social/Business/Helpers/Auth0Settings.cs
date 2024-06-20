namespace EliteThreadsWebApp.Services.Social.Business.Helpers
{
    public record Auth0Settings
    {
        public string Domain { get; init; }
        public string ClientId { get; init; }
        public string ClientSecret { get; init; }
        public string Audience { get; init; }
    }
}
