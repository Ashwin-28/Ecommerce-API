namespace Ecommerce_API.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImgeUrl { get; set; }
        public int  Stock { get; set; }
        public int  ItemsSold { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public bool IsActive { get; set; }
    }
}
