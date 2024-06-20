using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EliteThreadsWebApp.Services.Products.Domain.Entities
{
    public record Subcategories
    {
        [Key]
        public int SubcategoryId { get; init; }
        public string SubcategoryName { get; init; }
        public int CategoryId { get; init; }

        [ForeignKey("CategoryId")]
        public virtual Categories Categories { get; init; }
    }
}
