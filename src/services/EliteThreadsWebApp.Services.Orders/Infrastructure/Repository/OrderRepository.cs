using EliteThreadsWebApp.Services.Orders.Domain;
using EliteThreadsWebApp.Services.Orders.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace EliteThreadsWebApp.Services.Orders.Infrastructure.Repository
{
    public class OrderRepository(ApplicationDbContext db) : IOrderRepository
    {
        public async Task CreateOrderAsync(Order order)
        {
            var products = order.OrderDetails.Select(o => o.OrderProduct).ToList();
            foreach (var product in products)
            {
                var productFromDb = await db.OrderProducts.FirstOrDefaultAsync(
                    p => p.ProductId == product.ProductId
                );
                if (productFromDb == null)
                {
                    db.Add(product);
                    await db.SaveChangesAsync();
                }
            }

            var personalInfo = await db.PersonalInfos.FirstOrDefaultAsync(
                p => p.UserId == order.OrderHeader.UserId
            );
            if (personalInfo == null)
            {
                db.Add(new PersonalInfo { UserId = order.OrderHeader.UserId, });
                await db.SaveChangesAsync();
            }
            order.OrderHeader.DateCreated = DateTime.UtcNow;
            db.Add(order.OrderHeader);
            await db.SaveChangesAsync();

            foreach (var detail in order.OrderDetails)
            {
                detail.OrderProduct = null;
                db.Add(detail);
                await db.SaveChangesAsync();
            }
        }

        public async Task<bool> CancelOrderAsync(string orderHeaderId)
        {
            var orderHeaderFromDb =
                await db.OrderHeaders.FirstOrDefaultAsync(o => o.OrderHeaderId == orderHeaderId)
                ?? throw new InvalidDataException("Object doesn't exist");
            orderHeaderFromDb.OrderCancelled = true;
            return await Save();
        }

        public async Task<Order> GetOrderAsync(string orderHeaderId)
        {
            var orderHeaderFromDb =
                await db.OrderHeaders
                    .Include(o => o.PersonalInfo)
                    .FirstOrDefaultAsync(h => h.OrderHeaderId == orderHeaderId)
                ?? throw new InvalidDataException("Object doesn't exist");
            var orderDetailsFromDb =
                await db.OrderDetails
                    .Include(o => o.OrderHeader)
                    .Include(o => o.OrderProduct)
                    .Where(o => o.OrderHeaderId == orderHeaderFromDb.OrderHeaderId)
                    .ToListAsync() ?? [ ];
            return new() { OrderHeader = orderHeaderFromDb, OrderDetails = orderDetailsFromDb };
        }

        public async Task<PersonalInfo> GetPersonalInfoAsync(string userId)
        {
            return await db.PersonalInfos.FirstOrDefaultAsync(u => u.UserId == userId)
                ?? throw new InvalidDataException("Object doesn't exist.");
        }

        public async Task<PaginatedOrderList> GetOrdersByUserIdAsync(string userId, int? page)
        {
            var orderHeadersQuery = db.OrderHeaders
                .Where(o => o.UserId == userId)
                .Include(o => o.PersonalInfo)
                .OrderByDescending(o => o.DateCreated);

            var pageIndex = page ?? 1;
            if (pageIndex == 0)
            {
                pageIndex = 1;
            }
            var pageSize = 10;

            return await PaginatedOrderList.CreateAsync(
                orderHeadersQuery.Select(
                    oh =>
                        new Order
                        {
                            OrderHeader = oh,
                            OrderDetails = db.OrderDetails
                                .Include(od => od.OrderHeader)
                                .Include(od => od.OrderProduct)
                                .Where(od => od.OrderHeaderId == oh.OrderHeaderId)
                                .ToList()
                        }
                ),
                pageIndex,
                pageSize
            );
        }

        public async Task<PaginatedOrderList> GetPaidOrdersAsync(int? page)
        {
            var orderHeadersQuery = db.OrderHeaders
                .Include(o => o.PersonalInfo)
                .Where(o => o.PaymentComplete && !o.OrderCancelled)
                .OrderByDescending(o => o.DateCreated);

            var pageIndex = page ?? 1;
            if (pageIndex == 0)
            {
                pageIndex = 1;
            }
            var pageSize = 10;

            return await PaginatedOrderList.CreateAsync(
                orderHeadersQuery.Select(
                    oh =>
                        new Order
                        {
                            OrderHeader = oh,
                            OrderDetails = db.OrderDetails
                                .Include(od => od.OrderHeader)
                                .Include(od => od.OrderProduct)
                                .Where(od => od.OrderHeaderId == oh.OrderHeaderId)
                                .ToList()
                        }
                ),
                pageIndex,
                pageSize
            );
        }

        public async Task UpdatePaymentStatusAsync(string orderHeaderId)
        {
            var orderHeaderFromDb =
                await db.OrderHeaders.FirstOrDefaultAsync(o => o.OrderHeaderId == orderHeaderId)
                ?? throw new InvalidDataException("Object doesn't exist");
            orderHeaderFromDb.PaymentComplete = true;
            await db.SaveChangesAsync();
        }

        public async Task<bool> UpdatePersonalInfoAsync(PersonalInfo personalInfo)
        {
            db.PersonalInfos.Update(personalInfo);
            return await Save();
        }

        private async Task<bool> Save()
        {
            var result = await db.SaveChangesAsync();
            return result > 0;
        }
    }
}
