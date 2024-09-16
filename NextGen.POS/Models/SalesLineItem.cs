namespace NextGen.POS.Models
{
    public class SalesLineItem
    {
        public int Quantity { get; set; }
        public ProductDescription ProductDescription { get; set; }

        public SalesLineItem(ProductDescription desc, int quantity)
        {
            ProductDescription = desc;
            Quantity = quantity;
        }

        public double GetSubtotal()
        {
            return ProductDescription.Price * Quantity;
        }
    }
}