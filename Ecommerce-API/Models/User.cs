using Ecommerce_API.Models.Enums;

namespace Ecommerce_API.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }=string.Empty;
        public UserRole Role { get; set; } = UserRole.Guest;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public Cart? Cart { get; set; }

    }
}
