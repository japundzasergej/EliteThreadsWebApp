using System.ComponentModel.DataAnnotations;

namespace EliteThreadsWebApp.Services.Products.Domain.Entities
{
    public record Categories
    {
        [Key]
        public int CategoryId { get; init; }
        public string CategoryName { get; init; }
    }
}
