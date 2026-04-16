namespace Ecommerce_API.DTOs
{
    public class AuditLogDto
    {
        public Guid Id { get; set; }

        public Guid? UserId { get; set; }

        public string Action { get; set; }

        public string EntityType { get; set; }

        public string EntityId { get; set; }

        public string Details { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}