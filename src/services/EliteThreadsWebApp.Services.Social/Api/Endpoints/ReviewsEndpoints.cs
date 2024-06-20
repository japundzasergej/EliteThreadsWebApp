using EliteThreadsWebApp.Services.Social.Business.DTO.Reviews;
using EliteThreadsWebApp.Services.Social.Business.Reviews.Commands;
using EliteThreadsWebApp.Services.Social.Business.Reviews.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EliteThreadsWebApp.Services.Social.Api.Endpoints
{
    public static class ReviewEndpoints
    {
        public static void ConfigureReviewEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet(
                    "/social/reviews/{productId:int}",
                    async (ISender sender, [FromRoute] int productId) =>
                        Results.Ok(
                            await sender.Send(
                                new GetReviewsByProductIdQuery { ProductId = productId }
                            )
                        )
                )
                .Produces<List<ReviewsDTO>>(200);

            app.MapGet(
                    "/social/reviews/ratings/{productId:int}",
                    async (ISender sender, [FromRoute] int productId) =>
                        Results.Ok(
                            await sender.Send(
                                new GetRatingByProductIdQuery { ProductId = productId }
                            )
                        )
                )
                .Produces<ProductRatingDTO>(200);

            app.MapGet(
                    "/social/reviews/edit/{reviewId:int}",
                    async (ISender sender, [FromRoute] int reviewId) =>
                        Results.Ok(
                            await sender.Send(new GetReviewByReviewIdQuery { ReviewId = reviewId })
                        )
                )
                .Produces<ReviewsDTO>(200);

            app.MapGet(
                    "/social/reviews/rating/{userId}/product-{productId:int}",
                    async (ISender sender, [FromRoute] string userId, [FromRoute] int productId) =>
                        Results.Ok(
                            await sender.Send(
                                new GetUserRatingQuery { ProductId = productId, UserId = userId }
                            )
                        )
                )
                .Produces<UserRatingDTO?>(200);

            app.MapPost(
                    "/social/reviews/{productId:int}",
                    async (
                        ISender sender,
                        [FromRoute] int productId,
                        [FromBody] CreateReviewsDTO reviewDTO
                    ) =>
                        Results.Ok(
                            await sender.Send(
                                new CreateReviewCommand
                                {
                                    ProductId = productId,
                                    ReviewsDTO = reviewDTO
                                }
                            )
                        )
                )
                .Accepts<CreateReviewsDTO>("application/json")
                .Produces<bool>(201);
            app.MapPost(
                    "/social/reviews/add-rating",
                    async (ISender sender, [FromBody] UserRatingDTO dto) =>
                        Results.Ok(await sender.Send(new AddRatingCommand { DTO = dto }))
                )
                .Accepts<UserRatingDTO>("application/json")
                .Produces<bool>(201);

            app.MapPut(
                    "/social/reviews/{reviewId:int}",
                    async (
                        ISender sender,
                        [FromRoute] int reviewId,
                        [FromBody] EditReviewDTO reviewsDTO
                    ) =>
                        Results.Ok(
                            await sender.Send(
                                new EditReviewCommand
                                {
                                    ReviewId = reviewId,
                                    ReviewsDTO = reviewsDTO
                                }
                            )
                        )
                )
                .Accepts<EditReviewDTO>("application/json")
                .Produces<bool>(201);

            app.MapDelete(
                    "/social/reviews/{reviewId:int}",
                    async (ISender sender, [FromRoute] int reviewId) =>
                        Results.Ok(
                            await sender.Send(new DeleteReviewCommand { ReviewId = reviewId })
                        )
                )
                .Produces<bool>(202);
        }
    }
}
