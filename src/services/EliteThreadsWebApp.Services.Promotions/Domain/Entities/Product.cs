using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EliteThreadsWebApp.Services.Products.Domain.Entities;

namespace EliteThreadsWebApp.Services.Promotions.Domain.Entities
{
    public record Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; init; }
        public int? DiscountId { get; set; }

        [ForeignKey("DiscountId")]
        public virtual Discount? Discount { get; init; }
        public int? CollectionId { get; set; }

        [ForeignKey("CollectionId")]
        public virtual Collections? Collections { get; init; }
    }
}
