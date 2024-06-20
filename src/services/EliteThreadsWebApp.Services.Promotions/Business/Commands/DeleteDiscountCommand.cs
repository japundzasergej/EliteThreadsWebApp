using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Commands
{
    public class DeleteDiscountCommand : IRequest<bool>
    {
        public int? DiscountId { get; init; }
    }
}
