using System.Text.Json;
using AutoMapper;
using EliteThreadsWebApp.Services.Products.Business.DTO;
using EliteThreadsWebApp.Services.Products.Infrastructure.Repository;
using MediatR;

namespace EliteThreadsWebApp.Services.Products.Business.Queries
{
    public class GetUserWishlistQueryHandler(
        IProductRepository productRepository,
        IHttpClientFactory httpClientFactory,
        IMapper mapper
    ) : IRequestHandler<GetUserWishlistQuery, IEnumerable<ProductDTO>>
    {
        public async Task<IEnumerable<ProductDTO>> Handle(
            GetUserWishlistQuery request,
            CancellationToken cancellationToken
        )
        {
            var client = httpClientFactory.CreateClient("SocialApiClient");
            var builder = new UriBuilder(client.BaseAddress);
            builder.Path += $"/{request.UserId}";

            var response = await client.GetAsync(builder.Uri);
            response.EnsureSuccessStatusCode();

            var apiContent = await response.Content.ReadAsStringAsync();
            var productIds = JsonSerializer.Deserialize<List<int>>(apiContent);

            var products =
                await productRepository.GetProductsOnWishlistAsync([ .. productIds ]) ?? [ ];

            return products.Select(mapper.Map<ProductDTO>);
        }
    }
}
