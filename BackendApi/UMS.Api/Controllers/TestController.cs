using Microsoft.AspNetCore.Mvc;
using UMS.Api.Data;

namespace UMS.Api.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var count = _context.Users.Count();
            return Ok($"Connected. Users count: {count}");
        }
    }
}
