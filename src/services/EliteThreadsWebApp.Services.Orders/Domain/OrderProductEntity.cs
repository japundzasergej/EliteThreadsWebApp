using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EliteThreadsWebApp.Services.Orders.Domain
{
    public record OrderProductEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; init; }
        public string ProductName { get; init; }
        public string Image { get; init; }
    }
}
