using Ecommerce_API.Models.Enums;

namespace Ecommerce_API.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public OrderStatus Status { get; set; }= OrderStatus.Pending;
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime PlacedAt { get; set; }
        public DateTime UdpatedAt { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
