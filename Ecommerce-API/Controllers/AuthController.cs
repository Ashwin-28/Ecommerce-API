using Ecommerce_API.Data;
using Ecommerce_API.Dtos.Auth;
using Ecommerce_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly AuthServices _auth;

        public AuthController(AppDbContext context, AuthServices auth)
        {
            _context = context;
            _auth = auth;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            try
            {
                var token = await _auth.RegisterAsync(dto.UserName, dto.Email, dto.Password);
                return Ok(new { token });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _auth.LoginAsync(dto.UserName, dto.Password);
            if (token is null) return Unauthorized(new { error = "Invalid credentials" });
            return Ok(new { token });
        }
    }
}
