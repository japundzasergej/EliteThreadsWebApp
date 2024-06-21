using System.Text.Json;
using AutoMapper;
using EliteThreadsWebApp.Services.Social.Business.DTO.User;
using EliteThreadsWebApp.Services.Social.Business.Interfaces;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Users.Queries
{
    public class GetUserByUserIdQueryHandler(
        IAuth0ManagementService auth0ManagementService,
        IMapper mapper
    ) : IRequestHandler<GetUserByUserIdQuery, UserDTO>
    {
        public async Task<UserDTO> Handle(
            GetUserByUserIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var client = await auth0ManagementService.GetManagementApiClient();
            var response = await client.Users.GetAsync(request.UserId);
            var dto = mapper.Map<UserDTO>(response);
            dto.UserMetadata = System
                .Text
                .Json
                .JsonSerializer
                .Deserialize<UserMetadata>(
                    $"{response.UserMetadata}",
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );
            return dto;
        }
    }
}
