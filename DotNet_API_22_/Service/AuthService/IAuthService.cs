using DotNet_API_22_.Entities.Dtos.UserDtos;

namespace DotNet_API_22_.Service.AuthService
{
    public interface IAuthService
    {
        public Task<string> Login(LoginDto login);
        public Task<string> Register(RegisterDto register);
    }
}
