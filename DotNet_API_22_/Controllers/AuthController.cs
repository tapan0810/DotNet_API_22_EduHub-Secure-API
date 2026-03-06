using DotNet_API_22_.Entities.Dtos.UserDtos;
using DotNet_API_22_.Service.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_API_22_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<ActionResult<LoginDto>> Login(LoginDto loginDto)
        {
            var user = await authService.Login(loginDto);

            if (user is null)
                return BadRequest("User not Found");

            return Ok(user);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<LoginDto>> Register(RegisterDto registerDto)
        {
            
                var user = await authService.Register(registerDto);

                if (user is null)
                    return BadRequest("User Not Valid");

                return Ok(user);

            

        }
    }
}
