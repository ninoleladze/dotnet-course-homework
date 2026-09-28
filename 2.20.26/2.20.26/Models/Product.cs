namespace _2._20._26.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
    }
}
