using System.ComponentModel.DataAnnotations.Schema;
using EliteThreadsWebApp.Services.Orders.Domain;

namespace EliteThreadsWebApp.Services.Orders.Business.DTO
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
    }
}
