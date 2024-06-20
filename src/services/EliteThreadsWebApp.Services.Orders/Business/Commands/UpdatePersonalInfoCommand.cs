using EliteThreadsWebApp.Services.Orders.Business.DTO;
using MediatR;

namespace EliteThreadsWebApp.Services.Orders.Business.Commands
{
    public class UpdatePersonalInfoCommand : IRequest<bool>
    {
        public PersonalInfoDTO DTO { get; init; }
    }
}
