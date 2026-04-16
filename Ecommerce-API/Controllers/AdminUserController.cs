using Ecommerce_API.DTOs;
using Ecommerce_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        private readonly AdminUserService _service;

        public AdminUserController(AdminUserService service)
        {
            _service = service;
        }

        // GET ALL USERS
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users =
                await _service.GetAllUsersAsync();

            return Ok(users);
        }

        // GET USER BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user =
                await _service.GetUserByIdAsync(id);

            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        // CREATE USER
        [HttpPost]
        public async Task<IActionResult> CreateUser(
            [FromBody] CreateUserDto dto)
        {
            var result =
                await _service.CreateUserAsync(
                    dto.UserName,
                    dto.Email,
                    dto.Password,
                    dto.Role);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        // UPDATE USER
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(
            Guid id,
            [FromBody] UpdateUserDto dto)
        {
            var result =
                await _service.UpdateUserAsync(
                    id,
                    dto.UserName,
                    dto.Email,
                    dto.Role);

            if (!result.Success)
                return NotFound(result.Message);

            return Ok(result.Message);
        }

        // DEACTIVATE USER (Soft Delete)
        [HttpPatch("{id}/deactivate")]
        public async Task<IActionResult> DeactivateUser(Guid id)
        {
            var result =
                await _service.DeactivateUserAsync(id);

            if (!result.Success)
                return NotFound(result.Message);

            return Ok(result.Message);
        }
    }
}
