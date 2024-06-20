namespace EliteThreadsWebApp.Services.ExternalApi.DTO
{
    public record ImagesDTO
    {
        public byte[] imageBytes { get; init; }
        public string ContentType { get; init; }
        public string? ImageUrl { get; init; }
    }
}
