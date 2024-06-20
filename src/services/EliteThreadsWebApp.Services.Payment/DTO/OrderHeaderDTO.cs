using System.ComponentModel.DataAnnotations.Schema;

namespace EliteThreadsWebApp.Services.Payment.Business.DTO
{
    public record OrderHeaderDTO
    {
        public string OrderHeaderId { get; init; }
        public double TotalPrice { get; init; }
        public string UserId { get; init; }
        public virtual PersonalInfoDTO PersonalInfo { get; init; }
        public DateTime DateCreated { get; init; }
        public bool OrderCancelled { get; set; } = false;
        public bool PaymentComplete { get; init; }
        public bool PaymentError { get; init; }
    }
}
