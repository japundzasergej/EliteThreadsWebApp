namespace EliteThreadsWebApp.Services.Products.Business.DTO
{
    public record PaginatedListDTO
    {
        public IEnumerable<ProductDTO> Items { get; init; }
        public int TotalCount { get; init; }
        public int PageIndex { get; init; }
        public int TotalPages { get; init; }
        public int PageSize { get; init; }
        public bool HasPreviousPage { get; init; }
        public bool HasNextPage { get; init; }
    }
}
