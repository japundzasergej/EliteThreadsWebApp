using EliteThreadsWebApp.Services.Social.Domain.Entities;

namespace EliteThreadsWebApp.Services.Social.Infrastructure.Helpers
{
    public static class UpdateProductRating
    {
        public static void Update(
            Product product,
            float userInput,
            bool isNewRating,
            float? previousUserInput = null
        )
        {
            if (isNewRating)
            {
                product.TotalRatingSum += userInput;
                product.TotalRatingCount++;
            }
            else
            {
                if (previousUserInput > userInput)
                {
                    product.TotalRatingSum -= previousUserInput.Value - userInput;
                }
                else
                {
                    product.TotalRatingSum += userInput - previousUserInput.Value;
                }
            }

            product.Rating = product.TotalRatingSum / product.TotalRatingCount;

            if (product.Rating > 5)
            {
                product.Rating = 5;
            }

            UpdateStarRatingCounts(product, userInput, isNewRating, previousUserInput);
        }

        private static void UpdateStarRatingCounts(
            Product product,
            float userInput,
            bool isNewRating,
            float? previousUserInput
        )
        {
            if (isNewRating)
            {
                IncrementStarRatingCount(product, userInput);
            }
            else
            {
                DecrementStarRatingCount(product, previousUserInput.Value);
                IncrementStarRatingCount(product, userInput);
            }
        }

        private static void IncrementStarRatingCount(Product product, float rating)
        {
            if (rating >= 4.5f)
            {
                product.FiveStarRating++;
            }
            else if (rating >= 3.5f)
            {
                product.FourStarRating++;
            }
            else if (rating >= 2.5f)
            {
                product.ThreeStarRating++;
            }
            else if (rating >= 1.5f)
            {
                product.TwoStarRating++;
            }
            else
            {
                product.OneStarRating++;
            }
        }

        private static void DecrementStarRatingCount(Product product, float rating)
        {
            if (rating >= 4.5f)
            {
                product.FiveStarRating--;
            }
            else if (rating >= 3.5f)
            {
                product.FourStarRating--;
            }
            else if (rating >= 2.5f)
            {
                product.ThreeStarRating--;
            }
            else if (rating >= 1.5f)
            {
                product.TwoStarRating--;
            }
            else
            {
                product.OneStarRating--;
            }
        }
    }
}
