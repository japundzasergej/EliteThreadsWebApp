using EliteThreadsWebApp.Services.Products.Business.Commands;
using EliteThreadsWebApp.Services.Products.Business.DTO;
using EliteThreadsWebApp.Services.Products.Business.DTO.Products;
using EliteThreadsWebApp.Services.Products.Business.Queries;
using EliteThreadsWebApp.Services.Products.Infrastructure.Helpers;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EliteThreadsWebApp.Services.Products.Api
{
    public static class ProductEndpoints
    {
        public static void ConfigureProductEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet(
                    "/products",
                    async (
                        ISender sender,
                        [FromQuery] string? search,
                        [FromQuery] string? category,
                        [FromQuery] string? subcategory,
                        [FromQuery] string? orderBy,
                        [FromQuery] string? color,
                        [FromQuery] string? size,
                        [FromQuery] string? composition,
                        [FromQuery] string? priceMax,
                        [FromQuery] string? priceMin,
                        [FromQuery] string? collection,
                        [FromQuery] string? isNew,
                        [FromQuery] string? mustHave,
                        [FromQuery] int? page,
                        [FromQuery] int? pageNumber
                    ) =>
                        Results.Ok(
                            await sender.Send(
                                new GetProductsQuery
                                {
                                    QueryObject = new()
                                    {
                                        Search = search,
                                        Category = category,
                                        Subcategory = subcategory,
                                        OrderBy = orderBy,
                                        Size = size,
                                        Color = color,
                                        Composition = composition,
                                        PriceMax = priceMax,
                                        PriceMin = priceMin,
                                        Collection = collection,
                                        New = isNew,
                                        MustHave = mustHave,
                                        Page = page,
                                        PageNumber = pageNumber
                                    }
                                }
                            )
                        )
                )
                .Produces<PaginatedListDTO>(200);

            app.MapGet(
                    "/products/{productId:int}",
                    async (ISender sender, [FromRoute] int productId) =>
                        Results.Ok(
                            await sender.Send(new GetProductByIdQuery { ProductId = productId })
                        )
                )
                .Produces<ProductDTO>(200);

            app.MapGet(
                    "/products/wishlist/{userId}",
                    async (ISender sender, [FromRoute] string userId) =>
                        Results.Ok(await sender.Send(new GetUserWishlistQuery { UserId = userId }))
                )
                .Produces<IEnumerable<ProductDTO>>(200);

            app.MapPost(
                    "/products",
                    async (ISender sender, [FromBody] CreateProductDTO productDTO) =>
                        Results.Ok(
                            await sender.Send(new CreateProductCommand { ProductDTO = productDTO })
                        )
                )
                .Accepts<CreateProductDTO>("application/json")
                .Produces<bool>(201);

            app.MapPatch(
                    "/products/{productId:int}",
                    async (
                        ISender sender,
                        [FromRoute] int productId,
                        [FromBody] EditProductDTO productDTO
                    ) =>
                        Results.Ok(
                            await sender.Send(
                                new EditProductCommand
                                {
                                    ProductId = productId,
                                    ProductDTO = productDTO
                                }
                            )
                        )
                )
                .Accepts<EditProductDTO>("application/json")
                .Produces<bool>(201);

            app.MapDelete(
                    "/products/{productId:int}",
                    async (ISender sender, [FromRoute] int productId) =>
                        Results.Ok(
                            await sender.Send(new DeleteProductCommand { ProductId = productId })
                        )
                )
                .Produces<bool>(202);
        }
    }
}
