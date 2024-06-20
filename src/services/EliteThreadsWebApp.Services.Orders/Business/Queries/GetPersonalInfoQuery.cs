using EliteThreadsWebApp.Services.Orders.Business.DTO;
using MediatR;

namespace EliteThreadsWebApp.Services.Orders.Business.Queries
{
    public class GetPersonalInfoQuery : IRequest<PersonalInfoDTO>
    {
        public string UserId { get; init; }
    }
}
