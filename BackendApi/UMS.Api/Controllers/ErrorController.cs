using Microsoft.AspNetCore.Mvc;

namespace UMS.Api.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet("/error")]
        public IActionResult HandleError()
        {
            return Problem("Unexpected server error");
        }
    }
}
