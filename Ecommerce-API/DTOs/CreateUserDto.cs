using Ecommerce_API.Models.Enums;

namespace Ecommerce_API.DTOs
{
    public class CreateUserDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; }
    }
}
