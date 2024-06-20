namespace EliteThreadsWebApp.Services.Orders.Business.DTO
{
    public record PersonalInfoDTO
    {
        public string UserId { get; init; }
        public string? Name { get; init; }
        public string? Country { get; init; }
        public string? City { get; init; }
        public string? State { get; init; }
        public string? Address { get; init; }
    }
}
