using EliteThreadsWebApp.Services.Products.Domain.Enums;

namespace EliteThreadsWebApp.Services.Products.Business.DTO.Products
{
    public record EditProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; init; }
        public string ProductDescription { get; init; }
        public IEnumerable<string> ImageList { get; init; }
        public string Model { get; init; }
        public string Compositions { get; init; }
        public string Fabric { get; init; }
        public string Pattern { get; init; }
        public string Length { get; init; }
        public IEnumerable<string> Color { get; init; }
        public double Price { get; init; }
        public int ProductsLeft { get; init; }
        public bool New { get; init; }
        public bool MustHave { get; init; }
        public IEnumerable<Size> Size { get; init; }
    }
}
