namespace EliteThreadsWebApp.Services.Emailing.DTO
{
    public record UserEmailDTO
    {
        public string UserEmail { get; init; }
        public string FullName { get; init; }
    }
}
