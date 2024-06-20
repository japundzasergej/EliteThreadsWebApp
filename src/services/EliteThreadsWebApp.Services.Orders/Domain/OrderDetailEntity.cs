using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EliteThreadsWebApp.Services.Orders.Domain
{
    public record OrderDetailEntity
    {
        [Key]
        public int OrderDetailId { get; init; }
        public string OrderHeaderId { get; init; }

        [ForeignKey("OrderHeaderId")]
        public virtual OrderHeaderEntity OrderHeader { get; init; }
        public int SelectedSize { get; init; }
        public string SelectedColor { get; init; }
        public int ProductId { get; init; }

        [ForeignKey("ProductId")]
        public virtual OrderProductEntity OrderProduct { get; set; }
        public int Quantity { get; init; }
        public double IndividualPrice { get; init; }
    }
}
