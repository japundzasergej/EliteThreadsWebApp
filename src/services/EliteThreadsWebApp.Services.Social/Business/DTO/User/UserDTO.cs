using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EliteThreadsWebApp.Services.Social.Business.DTO.User
{
    public record UserDTO
    {
        public string? Picture { get; set; }
        public string? UserName { get; init; }
        public UserMetadata? UserMetadata { get; set; }
    };
}
