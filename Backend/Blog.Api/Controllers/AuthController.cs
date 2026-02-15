using Blog.Applications.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenService _jwtService;
        
        public AuthController(IJwtTokenService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            if (email == "admin" && password == "admin")
            {
                var token = _jwtService.GenerateToken("1", "Admin");
                return Ok(new {token});
            }
            return Unauthorized();
        }
    }
}
