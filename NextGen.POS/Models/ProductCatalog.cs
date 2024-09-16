namespace NextGen.POS.Models
{
    public class ProductCatalog
    {
        private readonly Dictionary<int, ProductDescription> _descriptions;

        public ProductCatalog()
        {
            // Add sample data
            _descriptions = new Dictionary<int, ProductDescription>
            {
                { 100, new ProductDescription(100, 3, "product 1") },
                { 200, new ProductDescription(200, 3, "product 2") }
            };
        }

        public ProductDescription GetProductDescription(int id)
        {
            _descriptions.TryGetValue(id, out ProductDescription description);
            return description;
        }
    }
}