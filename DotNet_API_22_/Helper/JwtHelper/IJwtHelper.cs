using DotNet_API_22_.Entities.Dtos.UserDtos;
using DotNet_API_22_.Entities.Models;

namespace DotNet_API_22_.Helper.JwtHelper
{
    public interface IJwtHelper
    {
        public string GenerateToken(User user);
    }
}
