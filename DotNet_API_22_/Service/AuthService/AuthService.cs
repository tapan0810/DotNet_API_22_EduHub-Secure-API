using AutoMapper;
using DotNet_API_22_.Data;
using DotNet_API_22_.Entities.Dtos.UserDtos;
using DotNet_API_22_.Entities.Models;
using DotNet_API_22_.Helper.JwtHelper;
using Microsoft.EntityFrameworkCore;

namespace DotNet_API_22_.Service.AuthService
{
    public class AuthService(EduHubDbContext _context,IMapper mapper,IJwtHelper jwtHelper) : IAuthService
    {
        public async Task<string> Login(LoginDto login)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == login.UserName);

            if (user is null)
                throw new Exception("User not found!");

            bool passwordValid = BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash);

            if (!passwordValid)
                throw new Exception("Invalid Credentials");

            return jwtHelper.GenerateToken(user);
        }

        public async Task<string> Register(RegisterDto register)
        {
            var user = mapper.Map<User>(register);

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(register.Password);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return "User Registered Successfully.";
        }
    }
}
