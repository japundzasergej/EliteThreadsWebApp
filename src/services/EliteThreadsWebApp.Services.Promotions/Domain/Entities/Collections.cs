using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EliteThreadsWebApp.Services.Promotions.Domain.Entities;

namespace EliteThreadsWebApp.Services.Products.Domain.Entities
{
    public record Collections
    {
        [Key]
        public int CollectionId { get; init; }
        public string CollectionName { get; init; }
    }
}
