namespace Ecommerce_API.Models
{
    public class AuditLog
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string Action { get; set; }
        public string EntityType { get; set; }
        public string EntityId { get; set; }
        public string Details { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}