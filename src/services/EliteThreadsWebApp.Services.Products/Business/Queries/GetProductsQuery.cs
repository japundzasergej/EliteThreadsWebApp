using EliteThreadsWebApp.Services.Products.Business.DTO;
using EliteThreadsWebApp.Services.Products.Infrastructure.Helpers;
using MediatR;

namespace EliteThreadsWebApp.Services.Products.Business.Queries
{
    public class GetProductsQuery : IRequest<PaginatedListDTO>
    {
        public QueryObjectDTO? QueryObject { get; set; }
    }
}
