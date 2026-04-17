using Ecommerce_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_API.Controllers
{
    [Route("api/admin/stats")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminStatsController : ControllerBase
    {
        private readonly AdminStatsService _service;

        public AdminStatsController(
            AdminStatsService service)
        {
            _service = service;
        }

        // GET /api/admin/stats
        [HttpGet]
        public async Task<IActionResult> GetStats()
        {
            var stats =
                await _service.GetStatsAsync();

            return Ok(stats);
        }
    }
}