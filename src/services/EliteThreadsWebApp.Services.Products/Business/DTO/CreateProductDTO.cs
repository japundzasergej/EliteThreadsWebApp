using EliteThreadsWebApp.Services.Products.Domain.Enums;

namespace EliteThreadsWebApp.Services.Products.Business.DTO.Products
{
    public record CreateProductDTO
    {
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
        public int ProductsLeft { get; init; }
        public double Price { get; init; }
        public bool New { get; init; }
        public bool MustHave { get; init; }
        public List<Size> Size { get; init; }
    }
}
