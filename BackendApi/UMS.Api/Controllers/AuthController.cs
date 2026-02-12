using Microsoft.AspNetCore.Mvc;
using UMS.Api.DTOs.Auth;
using UMS.Api.Services.Auth;

namespace UMS.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        public AuthController(IAuthService authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto dto)
        {
            var result = await _authService.LoginAsync(dto);

            if (!result.Success)
                return Unauthorized(result);

            var token =
                _tokenService.CreateToken(
                     result.UserId,
                     result.Email,
                     result.Roles);

            return Ok(new
            {
                token,
                result.Email,
                result.Roles
            });
        }
    }
}
