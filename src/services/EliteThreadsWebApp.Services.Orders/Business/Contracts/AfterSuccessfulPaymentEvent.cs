using EliteThreadsWebApp.Contracts;

namespace EliteThreadsWebApp.Contracts
{
    public class AfterSuccessfulPaymentEvent
    {
        public OrderHeader OrderHeader { get; init; }
        public IEnumerable<OrderDetail> OrderDetails { get; init; }
    }
}
