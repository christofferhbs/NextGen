namespace NextGen.POS.Models
{
    public class ProductDescription
    {
        public int Id { get; }
        public double Price { get; }
        public string Description { get; }

        public ProductDescription(int id, double price, string description)
        {
            Id = id;
            Price = price;
            Description = description;
        }
    }
}