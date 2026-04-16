using Ecommerce_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuditLogController(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL LOGS (with filtering + pagination)
        [HttpGet]
        public async Task<IActionResult> GetLogs(
            string? action,
            DateTime? date,
            int page = 1,
            int pageSize = 10)
        {
            var query = _context.AuditLogs.AsQueryable();

            // FILTER: Action (CREATE / UPDATE / DELETE)
            if (!string.IsNullOrEmpty(action))
            {
                query = query.Where(x => x.Action == action);
            }

            // FILTER: Date
            if (date.HasValue)
            {
                query = query.Where(x => x.CreatedAt.Date == date.Value.Date);
            }

            // TOTAL COUNT (for pagination)
            var totalRecords = await query.CountAsync();

            // PAGINATION
            var logs = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(new
            {
                totalRecords,
                page,
                pageSize,
                data = logs
            });
        }

        // GET SINGLE LOG
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogById(Guid id)
        {
            var log = await _context.AuditLogs
                .FirstOrDefaultAsync(x => x.Id == id);

            if (log == null)
                return NotFound("Log not found");

            return Ok(log);
        }
    }
}
