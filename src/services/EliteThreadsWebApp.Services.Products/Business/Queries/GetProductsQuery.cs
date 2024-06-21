using EliteThreadsWebApp.Services.Products.Business.DTO;
using MediatR;

namespace EliteThreadsWebApp.Services.Products.Business.Queries
{
    public class GetProductsQuery : IRequest<PaginatedListDTO>
    {
        public QueryObjectDTO? QueryObject { get; set; }
    }
}
