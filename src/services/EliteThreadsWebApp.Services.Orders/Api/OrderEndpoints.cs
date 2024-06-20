using EliteThreadsWebApp.Services.Orders.Business.Commands;
using EliteThreadsWebApp.Services.Orders.Business.DTO;
using EliteThreadsWebApp.Services.Orders.Business.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EliteThreadsWebApp.Services.Orders.Api
{
    public static class OrderEndpoints
    {
        public static void ConfigureOrderEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet(
                    "/orders",
                    async (ISender sender, [FromQuery] int? page) =>
                        Results.Ok(await sender.Send(new GetPaidOrdersQuery { Page = page }))
                )
                .Produces<PaginatedOrderListDTO>(200);

            app.MapGet(
                    "/orders/user-list/{userId}",
                    async (ISender sender, [FromRoute] string userId, [FromQuery] int? page) =>
                        Results.Ok(
                            await sender.Send(
                                new GetOrdersByUserIdQuery { UserId = userId, Page = page }
                            )
                        )
                )
                .Produces<PaginatedOrderListDTO>(200);

            app.MapGet(
                    "/orders/personal-info/{userId}",
                    async (ISender sender, [FromRoute] string userId) =>
                        Results.Ok(await sender.Send(new GetPersonalInfoQuery { UserId = userId }))
                )
                .Produces<PersonalInfoDTO>(200);

            app.MapGet(
                    "/orders/{orderHeaderId}",
                    async (ISender sender, [FromRoute] string orderHeaderId) =>
                        Results.Ok(
                            await sender.Send(new GetOrderQuery { OrderHeaderId = orderHeaderId })
                        )
                )
                .Produces<OrderDTO>(200);

            app.MapPatch(
                    "/orders/personal-info",
                    async (ISender sender, [FromBody] PersonalInfoDTO dto) =>
                        Results.Ok(await sender.Send(new UpdatePersonalInfoCommand { DTO = dto }))
                )
                .Accepts<PersonalInfoDTO>("application/json")
                .Produces<bool>(201);

            app.MapPost(
                    "/orders/cancel/{orderHeaderId}",
                    async (ISender sender, [FromRoute] string orderHeaderId) =>
                        Results.Ok(
                            await sender.Send(
                                new CancelOrderCommand { OrderHeaderId = orderHeaderId }
                            )
                        )
                )
                .Produces<bool>(202);
        }
    }
}
