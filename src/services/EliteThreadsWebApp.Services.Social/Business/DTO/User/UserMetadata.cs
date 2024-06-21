namespace EliteThreadsWebApp.Services.Social.Business.DTO.User
{
    public record UserMetadata
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Country { get; init; }
        public string? State { get; init; }
        public string? City { get; init; }
        public string? Address { get; init; }
    }
}
