using EliteThreadsWebApp.Services.Social.Business.DTO.User;
using EliteThreadsWebApp.Services.Social.Business.Users.Commands;
using EliteThreadsWebApp.Services.Social.Business.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EliteThreadsWebApp.Services.Social.Api.Endpoints
{
    public static class UserProfileEndpoints
    {
        public static void ConfigureUserEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet(
                    "/social/user/{userId}",
                    async (ISender sender, [FromRoute] string userId) =>
                        Results.Ok(await sender.Send(new GetUserByUserIdQuery { UserId = userId }))
                )
                .Produces<UserDTO>(200);

            app.MapGet(
                    "/social/user/{userId}/email",
                    async (ISender sender, [FromRoute] string userId) =>
                        Results.Ok(await sender.Send(new GetUserEmailQuery { UserId = userId }))
                )
                .Produces<UserEmailDTO>(200);

            app.MapPatch(
                    "/social/user/{userId}",
                    async (ISender sender, [FromRoute] string userId, [FromBody] UserDTO dto) =>
                        Results.Ok(
                            await sender.Send(new UpdateUserCommand { UserId = userId, DTO = dto })
                        )
                )
                .Accepts<UserDTO>("application/json")
                .Produces<bool>(201);
            app.MapPatch(
                "/social/user/password/{userId}",
                async (
                    ISender sender,
                    [FromRoute] string userId,
                    [FromBody] UpdatePasswordDTO dto
                ) =>
                    Results.Ok(
                        await sender.Send(
                            new UpdateUserPasswordCommand { UserId = userId, DTO = dto }
                        )
                    )
            );

            app.MapDelete(
                    "/social/user/{userId}",
                    async (ISender sender, [FromRoute] string userId) =>
                        Results.Ok(await sender.Send(new DeleteUserCommand { UserId = userId }))
                )
                .Produces<bool>(202);

            app.MapGet(
                    "/social/user/wishlist/{userId}",
                    async (ISender sender, [FromRoute] string userId) =>
                        Results.Ok(
                            await sender.Send(new GetWishlistByUserIdQuery { UserId = userId })
                        )
                )
                .Produces<List<int>>(200);

            app.MapPost(
                    "/social/user/wishlist/{userId}/{productId:int}",
                    async (ISender sender, [FromRoute] string userId, [FromRoute] int productId) =>
                        Results.Ok(
                            await sender.Send(
                                new AddProductToWishlistCommand
                                {
                                    UserId = userId,
                                    ProductId = productId
                                }
                            )
                        )
                )
                .Produces<bool>(201);

            app.MapDelete(
                    "/social/user/wishlist/{userId}/{productId:int}",
                    async (ISender sender, [FromRoute] string userId, [FromRoute] int productId) =>
                        Results.Ok(
                            await sender.Send(
                                new RemoveProductFromWishlistCommand
                                {
                                    UserId = userId,
                                    ProductId = productId
                                }
                            )
                        )
                )
                .Produces<bool>(202);
        }
    }
}
