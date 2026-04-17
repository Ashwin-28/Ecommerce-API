using Ecommerce_API.Data;
using Ecommerce_API.DTOs;
using Microsoft.AspNetCore.Identity;
using Ecommerce_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_API.Services
{
    public class AdminStatsService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public AdminStatsService(
            AppDbContext context,
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<AdminStatsDto> GetStatsAsync()
        {
            var totalUsers =
                await _userManager.Users.CountAsync();

            var activeUsers =
                await _userManager.Users
                    .Where(u => u.IsActive)
                    .CountAsync();

            var totalAuditLogs =
                await _context.AuditLogs.CountAsync();

            var activeSessions =
                await _context.ActiveSessions
                    .Where(s => s.IsActive)
                    .CountAsync();

            return new AdminStatsDto
            {
                TotalUsers = totalUsers,
                ActiveUsers = activeUsers,
                TotalAuditLogs = totalAuditLogs,
                ActiveSessions = activeSessions
            };
        }
    }
}