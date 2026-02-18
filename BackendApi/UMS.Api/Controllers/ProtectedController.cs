using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UMS.Api.Controllers
{
    [ApiController]
    [Route("api/protected")]
    [Authorize]
    public class ProtectedController : ControllerBase
    {
        [HttpGet("testtokenexpiry")]
        public IActionResult Get()
        {
            return Ok("You are authorized");
        }
    }
    
}
