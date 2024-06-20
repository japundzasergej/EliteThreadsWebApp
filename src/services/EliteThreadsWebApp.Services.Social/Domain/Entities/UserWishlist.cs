using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EliteThreadsWebApp.Services.Social.Domain.Entities
{
    public record UserWishlist
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UserId { get; init; }
        public List<int> ProductIds { get; init; }
    }
}
