using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EliteThreadsWebApp.Services.Orders.Domain
{
    public record PersonalInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UserId { get; init; }
        public string? Name { get; init; }
        public string? Country { get; init; }
        public string? City { get; init; }
        public string? State { get; init; }
        public string? Address { get; init; }
    }
}
