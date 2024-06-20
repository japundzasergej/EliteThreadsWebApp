using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EliteThreadsWebApp.Services.ShoppingCart.Domain
{
    public record CartDetail
    {
        [Key]
        public int CartDetailId { get; set; }
        public int CartHeaderId { get; set; }

        [ForeignKey("CartHeaderId")]
        public virtual CartHeader CartHeader { get; init; }
        public int ProductId { get; init; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public string SelectedColor { get; set; }
        public int SelectedSize { get; set; }
    }
}
