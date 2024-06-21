using System.ComponentModel.DataAnnotations;

namespace EliteThreadsWebApp.Services.Products.Domain.Entities
{
    public record Collections
    {
        [Key]
        public int CollectionId { get; init; }
        public string CollectionName { get; init; }
    }
}
