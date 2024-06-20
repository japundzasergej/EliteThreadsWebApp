namespace EliteThreadsWebApp.Services.ExternalApi.DTO
{
    public record GeolocationDTO
    {
        public string Country { get; init; }
        public string Flag { get; init; }
    }
}
