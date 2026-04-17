namespace Ecommerce_API.Models
{
    public class ActiveSession
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime LoginTime { get; set; }

        public DateTime ExpiryTime { get; set; }

        public bool IsActive { get; set; }
    }
}