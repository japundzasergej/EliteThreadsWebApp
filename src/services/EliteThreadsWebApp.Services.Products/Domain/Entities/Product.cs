using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EliteThreadsWebApp.Services.Products.Domain.Enums;

namespace EliteThreadsWebApp.Services.Products.Domain.Entities
{
    public record Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; init; }
        public string ProductDescription { get; init; }
        public List<string> ImageList { get; set; }
        public string Model { get; init; }
        public string Compositions { get; init; }
        public string Fabric { get; init; }
        public string Pattern { get; init; }
        public string Length { get; init; }
        public List<string> Color { get; init; }
        public int SubcategoryId { get; set; }

        [ForeignKey("SubcategoryId")]
        public virtual Subcategories Subcategories { get; init; }
        public double Price { get; init; }
        public bool IsInStock { get; set; } = true;
        public float Rating { get; set; } = 0;
        public int TotalRatingCount { get; set; } = 0;
        public int ProductsLeft { get; set; }
        public bool HasDiscount { get; set; } = false;
        public int? DiscountId { get; set; } = null;
        public string? DiscountName { get; set; }
        public int? DiscountAmount { get; set; }
        public bool IsInCollection { get; set; } = false;
        public int? CollectionId { get; set; } = null;
        public string? CollectionName { get; set; }
        public bool New { get; init; } = false;
        public bool MustHave { get; init; } = false;
        public List<Size> Size { get; init; }
    }
}
