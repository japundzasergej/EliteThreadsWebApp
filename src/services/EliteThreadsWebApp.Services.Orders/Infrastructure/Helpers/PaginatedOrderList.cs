using EliteThreadsWebApp.Services.Orders.Domain;
using Microsoft.EntityFrameworkCore;

namespace EliteThreadsWebApp.Services.Orders.Infrastructure.Helpers
{
    public class PaginatedOrderList
    {
        public IEnumerable<Order> Items { get; private set; }
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set; }
        public int PageSize { get; private set; }

        private PaginatedOrderList(
            IEnumerable<Order> items,
            int totalCount,
            int pageIndex,
            int pageSize
        )
        {
            Items = items;
            TotalCount = totalCount;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            PageSize = pageSize;
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public static async Task<PaginatedOrderList> CreateAsync(
            IQueryable<Order> source,
            int pageIndex,
            int pageSize
        )
        {
            var totalCount = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedOrderList(items, totalCount, pageIndex, pageSize);
        }
    }
}
