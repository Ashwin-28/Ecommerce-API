namespace Ecommerce_API.Models
{
    public class Cart
    {
        public Guid id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdateTime { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

    }
}


