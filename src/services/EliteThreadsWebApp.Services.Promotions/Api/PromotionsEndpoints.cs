using EliteThreadsWebApp.Services.Promotions.Business.Commands;
using EliteThreadsWebApp.Services.Promotions.Business.DTO;
using EliteThreadsWebApp.Services.Promotions.Business.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EliteThreadsWebApp.Services.Promotions.Api
{
    public static class PromotionsEndpoints
    {
        public static void ConfigurePromotionsEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet(
                    "/promotions/discounts",
                    async (ISender sender) =>
                        Results.Ok(await sender.Send(new GetActiveDiscountsQuery()))
                )
                .Produces<IEnumerable<DiscountDTO>>(200);

            app.MapGet(
                    "/promotions/collections",
                    async (ISender sender) =>
                        Results.Ok(await sender.Send(new GetCollectionsQuery()))
                )
                .Produces<IEnumerable<CollectionsDTO>>(200);

            app.MapGet(
                    "/promotions/promotion-messages",
                    async (ISender sender) =>
                        Results.Ok(await sender.Send(new GetActivePromotionsQuery()))
                )
                .Produces<IEnumerable<PromotionsDTO>>(200);

            app.MapPost(
                    "/promotions/discount",
                    async (ISender sender, [FromBody] CreateDiscountDTO dto) =>
                        Results.Ok(
                            await sender.Send(new CreateDiscountCommand { DiscountDTO = dto })
                        )
                )
                .Accepts<CreateDiscountDTO>("application/json")
                .Produces<bool>(201);

            app.MapPost(
                    "/promotions/collections",
                    async (ISender sender, [FromBody] CreateCollectionDTO dto) =>
                        Results.Ok(
                            await sender.Send(new CreateCollectionCommand { CollectionsDTO = dto })
                        )
                )
                .Accepts<CreateCollectionDTO>("application/json")
                .Produces<bool>(201);

            app.MapPost(
                    "/promotions/promotion-messages",
                    async (ISender sender, [FromBody] CreatePromotionDTO dto) =>
                        Results.Ok(
                            await sender.Send(new CreatePromotionMessageCommand { DTO = dto })
                        )
                )
                .Accepts<CreatePromotionDTO>("application/json")
                .Produces<bool>(201);

            app.MapPost(
                    "/promotions/discount/{discountId:int}/product-{productId:int}",
                    async (ISender sender, [FromRoute] int discountId, [FromRoute] int productId) =>
                        Results.Ok(
                            await sender.Send(
                                new AddDiscountToProductCommand
                                {
                                    DiscountId = discountId,
                                    ProductId = productId
                                }
                            )
                        )
                )
                .Produces<bool>(201);

            app.MapPost(
                    "/promotions/collections/{collectionId:int}/product-{productId:int}",
                    async (
                        ISender sender,
                        [FromRoute] int collectionId,
                        [FromRoute] int productId
                    ) =>
                        Results.Ok(
                            await sender.Send(
                                new AddCollectionToProductCommand
                                {
                                    CollectionId = collectionId,
                                    ProductId = productId
                                }
                            )
                        )
                )
                .Produces<bool>(201);

            app.MapDelete(
                    "/promotions/discount/{discountId:int}",
                    async (ISender sender, [FromRoute] int discountId) =>
                        Results.Ok(
                            await sender.Send(new DeleteDiscountCommand { DiscountId = discountId })
                        )
                )
                .Produces<bool>(202);

            app.MapDelete(
                    "/promotions/collections/{collectionId:int}",
                    async (ISender sender, [FromRoute] int collectionId) =>
                        Results.Ok(
                            await sender.Send(
                                new DeleteCollectionCommand { CollectionId = collectionId }
                            )
                        )
                )
                .Produces<bool>(202);

            app.MapDelete(
                    "/promotions/promotion-messages/{promotionId:int}",
                    async (ISender sender, [FromRoute] int promotionId) =>
                        Results.Ok(
                            await sender.Send(
                                new DeletePromotionCommand { PromotionId = promotionId }
                            )
                        )
                )
                .Produces<bool>(202);

            app.MapDelete(
                    "/promotions/discount/{discountId:int}/product-{productId:int}",
                    async (ISender sender, [FromRoute] int discountId, [FromRoute] int productId) =>
                        Results.Ok(
                            await sender.Send(
                                new RemoveDiscountFromProductCommand
                                {
                                    DiscountId = discountId,
                                    ProductId = productId
                                }
                            )
                        )
                )
                .Produces<bool>(202);

            app.MapDelete(
                    "/promotions/collections/{collectionId:int}/product-{productId:int}",
                    async (
                        ISender sender,
                        [FromRoute] int productId,
                        [FromRoute] int collectionId
                    ) =>
                        Results.Ok(
                            await sender.Send(
                                new RemoveCollectionFromProductCommand
                                {
                                    CollectionId = collectionId,
                                    ProductId = productId
                                }
                            )
                        )
                )
                .Produces<bool>(202);
        }
    }
}
