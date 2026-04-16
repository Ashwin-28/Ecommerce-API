using Ecommerce_API.Models;
using Ecommerce_API.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;    

namespace Ecommerce_API.Services
{
    public class AdminUserService
    {
        private readonly UserManager<User> _userManager;

        public AdminUserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        // GET ALL USERS
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userManager.Users
                .OrderByDescending(u => u.CreatedDate)
                .ToListAsync();
        }

        // GET USER BY ID
        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _userManager.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        // CREATE USER
        public async Task<(bool Success, string Message)> CreateUserAsync(
            string userName,
            string email,
            string password,
            UserRole role)
        {
            var existingUser =
                await _userManager.FindByNameAsync(userName);

            if (existingUser != null)
                return (false, "Username already exists");

            var existingEmail =
                await _userManager.FindByEmailAsync(email);

            if (existingEmail != null)
                return (false, "Email already exists");

            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = userName,
                Email = email,
                Role = role,
                CreatedDate = DateTime.UtcNow,
                IsActive = true
            };

            var result =
                await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ",
                    result.Errors.Select(e => e.Description));

                return (false, errors);
            }

            return (true, "User created successfully");
        }

        // UPDATE USER
        public async Task<(bool Success, string Message)> UpdateUserAsync(
            Guid id,
            string userName,
            string email,
            UserRole role)
        {
            var user =
                await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
                return (false, "User not found");

            user.UserName = userName;
            user.Email = email;
            user.Role = role;

            var result =
                await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ",
                    result.Errors.Select(e => e.Description));

                return (false, errors);
            }

            return (true, "User updated successfully");
        }

        // DEACTIVATE USER (Soft Delete)
        public async Task<(bool Success, string Message)> DeactivateUserAsync(Guid id)
        {
            var user =
                await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
                return (false, "User not found");

            user.IsActive = false;

            var result =
                await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ",
                    result.Errors.Select(e => e.Description));

                return (false, errors);
            }

            return (true, "User deactivated successfully");
        }
    }
}

