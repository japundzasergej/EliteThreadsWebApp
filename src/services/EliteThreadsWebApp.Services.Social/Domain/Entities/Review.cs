using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EliteThreadsWebApp.Services.Social.Domain.Entities
{
    public record Review
    {
        [Key]
        public int ReviewId { get; init; }
        public string UserId { get; init; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
        public string Title { get; init; }
        public string Description { get; init; }
        public DateTime CreatedDate { get; set; }
        public bool IsEdited { get; set; } = false;
        public int ProductId { get; set; }
    }
}
