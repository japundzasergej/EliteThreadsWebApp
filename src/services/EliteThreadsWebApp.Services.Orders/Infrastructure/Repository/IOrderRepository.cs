using EliteThreadsWebApp.Services.Orders.Domain;
using EliteThreadsWebApp.Services.Orders.Infrastructure.Helpers;

namespace EliteThreadsWebApp.Services.Orders.Infrastructure.Repository
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);
        Task<PersonalInfo> GetPersonalInfoAsync(string userId);
        Task<PaginatedOrderList> GetPaidOrdersAsync(int? page);
        Task<PaginatedOrderList> GetOrdersByUserIdAsync(string userId, int? page);
        Task<Order> GetOrderAsync(string orderHeaderId);
        Task<bool> CancelOrderAsync(string orderHeaderId);
        Task<bool> UpdatePersonalInfoAsync(PersonalInfo personalInfo);
        Task UpdatePaymentStatusAsync(string orderHeaderId);
    }
}
