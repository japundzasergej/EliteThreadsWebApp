namespace EliteThreadsWebApp.Services.Products.Infrastructure
{
    public record QueryObject
    {
        public string? Search { get; init; }
        public string? Category { get; init; }
        public string? Subcategory { get; init; }
        public string? OrderBy { get; init; }
        public string? Color { get; init; }
        public string? Size { get; init; }
        public string? Composition { get; init; }
        public string? PriceMax { get; init; }
        public string? PriceMin { get; init; }
        public string? Collection { get; init; }
        public string? New { get; init; }
        public string? MustHave { get; init; }
        public int? Page { get; init; }
        public int? PageNumber { get; init; }
    }
}
