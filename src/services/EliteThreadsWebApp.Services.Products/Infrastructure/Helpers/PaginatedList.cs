using EliteThreadsWebApp.Services.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EliteThreadsWebApp.Services.Products.Infrastructure.Helpers
{
    public class PaginatedList
    {
        public IEnumerable<Product> Items { get; private set; }
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set; }
        public int PageSize { get; private set; }

        private PaginatedList(
            IEnumerable<Product> items,
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

        public static async Task<PaginatedList> CreateAsync(
            IQueryable<Product> source,
            int pageIndex,
            int pageSize
        )
        {
            var totalCount = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList(items, totalCount, pageIndex, pageSize);
        }
    }
}
