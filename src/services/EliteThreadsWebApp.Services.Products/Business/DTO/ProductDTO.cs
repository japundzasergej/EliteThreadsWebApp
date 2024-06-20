using EliteThreadsWebApp.Services.Products.Domain.Enums;

namespace EliteThreadsWebApp.Services.Products.Business.DTO
{
    public record ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; init; }
        public string ProductDescription { get; init; }
        public List<string> ImageList { get; init; }
        public string Model { get; init; }
        public string Compositions { get; init; }
        public string Fabric { get; init; }
        public string Pattern { get; init; }
        public string Length { get; init; }
        public List<string> Color { get; init; }
        public int SubcategoryId { get; init; }
        public virtual SubcategoriesDTO Subcategories { get; init; }
        public double Price { get; init; }
        public float Rating { get; init; }
        public int TotalRatingCount { get; init; }
        public bool IsInStock { get; init; }
        public int ProductsLeft { get; init; }
        public bool HasDiscount { get; set; }
        public int? DiscountId { get; set; }
        public string? DiscountName { get; set; }
        public int? DiscountAmount { get; set; }
        public bool IsInCollection { get; set; }
        public int? CollectionId { get; set; }
        public string? CollectionName { get; set; }
        public bool New { get; init; }
        public bool MustHave { get; init; }
        public List<Size> Size { get; init; }
    }
}
