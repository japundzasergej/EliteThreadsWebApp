using EliteThreadsWebApp.Services.ShoppingCart.Business.Commands;
using EliteThreadsWebApp.Services.ShoppingCart.Business.DTO;
using EliteThreadsWebApp.Services.ShoppingCart.Business.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EliteThreadsWebApp.Services.ShoppingCart.Api
{
    public static class ShoppingCartEndpoints
    {
        public static void ConfigureShoppingCartEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet(
                    "/shopping-cart/{userId}",
                    async (ISender sender, [FromRoute] string userId) =>
                        Results.Ok(await sender.Send(new GetShoppingCartQuery { UserId = userId }))
                )
                .Produces<CartDTO>(200);

            app.MapPost(
                    "/shopping-cart",
                    async (ISender sender, [FromBody] AddUpdateProductToCartDTO dto) =>
                        Results.Ok(await sender.Send(new CreateUpdateCartCommand { DTO = dto }))
                )
                .Accepts<AddUpdateProductToCartDTO>("application/json")
                .Produces<CartDTO>(201);

            app.MapPost(
                    "/shopping-cart/checkout",
                    async (ISender sender, [FromBody] CheckoutDTO dto) =>
                        Results.Ok(await sender.Send(new CheckoutCartCommand { DTO = dto }))
                )
                .Accepts<CheckoutDTO>("application/json")
                .Produces<OrderPlacedDTO>(201);

            app.MapDelete(
                    "/shopping-cart/{cartDetailId:int}",
                    async (ISender sender, [FromRoute] int cartDetailId) =>
                        Results.Ok(
                            await sender.Send(
                                new RemoveFromCartCommand { CartDetailId = cartDetailId }
                            )
                        )
                )
                .Produces<bool>(202);

            app.MapDelete(
                    "/shopping-cart/clear/{userId}",
                    async (ISender sender, [FromRoute] string userId) =>
                        Results.Ok(await sender.Send(new ClearCartCommand { UserId = userId }))
                )
                .Produces<bool>(202);
        }
    }
}
