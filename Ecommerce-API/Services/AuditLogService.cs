using Ecommerce_API.Data;
using Ecommerce_API.Models;

namespace Ecommerce_API.Services
{
    public class AuditLogService
    {
        private readonly AppDbContext _context;

        public AuditLogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task LogAsync(
            Guid? userId,
            string action,
            string entityType,
            string entityId,
            string details = "")
        {
            var log = new AuditLog
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Action = action,
                EntityType = entityType,
                EntityId = entityId,
                Details = details,
                CreatedAt = DateTime.UtcNow
            };

            _context.AuditLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
