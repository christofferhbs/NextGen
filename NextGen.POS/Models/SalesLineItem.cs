namespace NextGen.POS.Models
{
    public class SalesLineItem
    {
        public int Quantity { get; }
        public ProductDescription ProductDescription { get; }

        private readonly double _subtotal;

        public SalesLineItem(ProductDescription desc, int quantity)
        {
            ProductDescription = desc;
            Quantity = quantity;
            _subtotal = ProductDescription.Price * Quantity;
        }

        public double GetSubtotal()
        {
            return _subtotal;
        }
    }
}