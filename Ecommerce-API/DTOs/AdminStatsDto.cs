namespace Ecommerce_API.DTOs
{
    public class AdminStatsDto
    {
        public int TotalUsers { get; set; }

        public int ActiveUsers { get; set; }

        public int TotalAuditLogs { get; set; }

        public int ActiveSessions { get; set; }
    }
}