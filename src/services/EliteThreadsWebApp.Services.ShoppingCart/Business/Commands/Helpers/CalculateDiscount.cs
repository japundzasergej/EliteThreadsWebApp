namespace EliteThreadsWebApp.Services.ShoppingCart.Business.Commands.Helpers
{
    public static class CalculateDiscount
    {
        public static double Calculate(double price, int discountAmount)
        {
            return price - (price * (discountAmount / 100));
        }
    }
}
