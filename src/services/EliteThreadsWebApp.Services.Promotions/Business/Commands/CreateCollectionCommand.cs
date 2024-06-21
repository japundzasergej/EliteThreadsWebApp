using EliteThreadsWebApp.Services.Promotions.Business.DTO;
using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Commands
{
    public class CreateCollectionCommand : IRequest<bool>
    {
        public CreateCollectionDTO CollectionsDTO { get; init; }
    }
}
