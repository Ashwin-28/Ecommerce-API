using Ecommerce_API.Models.Enums;

namespace Ecommerce_API.DTOs
{
    public class UpdateUserDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }
    }
}
