using Microsoft.AspNetCore.Mvc;
using UMS.Api.DTOs.Auth;
using UMS.Api.Services.Auth;

namespace UMS.Api.Controllers
{
    [ApiController]
    [Route("api/auth-test")]
    public class AuthTestController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthTestController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            return Ok(result);
        }
    }
}
