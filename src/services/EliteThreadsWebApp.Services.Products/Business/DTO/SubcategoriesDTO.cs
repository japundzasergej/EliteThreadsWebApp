namespace EliteThreadsWebApp.Services.Products.Business.DTO
{
    public record SubcategoriesDTO
    {
        public int SubcategoryId { get; init; }
        public string SubcategoryName { get; init; }
        public int CategoryId { get; init; }
        public virtual CategoriesDTO Categories { get; init; }
    }
}
