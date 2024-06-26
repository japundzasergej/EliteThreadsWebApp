namespace EliteThreadsWebApp.Services.Emailing.SendGrid
{
    public record SendGridSettings
    {
        public string ApiKey { get; init; }
        public string Email { get; init; }
        public string Frontend { get; init; }
    }
}
