using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EliteThreadsWebApp.Services.Orders.Domain
{
    public record OrderHeaderEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string OrderHeaderId { get; init; }
        public double TotalPrice { get; init; }
        public string UserId { get; init; }

        [ForeignKey("UserId")]
        public virtual PersonalInfo PersonalInfo { get; init; }
        public DateTime DateCreated { get; set; }
        public bool OrderCancelled { get; set; } = false;
        public bool PaymentComplete { get; set; } = false;
    }
}
