namespace NextGen.POS.Models
{
    public class CustomerCatalog
    {
        private readonly Dictionary<int, CustomerDescription> _descriptions;

        public CustomerCatalog()
        {
            // Add sample data
            _descriptions = new Dictionary<int, CustomerDescription>
            {
                { 100, new CustomerDescription(100, "Navn Et", 10) },
                { 200, new CustomerDescription(200, "Navn To", 10) }
            };
        }

        public CustomerDescription GetCustomerDescription(int id)
        {
            _descriptions.TryGetValue(id, out CustomerDescription description);
            return description;
        }
    }
}