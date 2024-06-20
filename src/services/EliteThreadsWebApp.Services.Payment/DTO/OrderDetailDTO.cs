using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EliteThreadsWebApp.Services.Payment.Business.DTO
{
    public record OrderDetailDTO
    {
        public int OrderDetailId { get; init; }
        public string OrderHeaderId { get; init; }
        public virtual OrderHeaderDTO OrderHeader { get; init; }
        public int SelectedSize { get; init; }
        public string SelectedColor { get; init; }
        public int ProductId { get; init; }
        public virtual OrderProductDTO OrderProduct { get; set; }
        public int Quantity { get; init; }
        public double IndividualPrice { get; init; }
    }
}
