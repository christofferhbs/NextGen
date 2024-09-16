using NextGen.POS.Controllers;

namespace NextGen.POS.Models
{
    public class Store
    {
        public ProductCatalog ProductCatalog { get; } = new ProductCatalog();
        public CustomerCatalog CustomerCatalog { get; } = new CustomerCatalog();
        public Register Register { get; }

        public Store()
        {
            Register = new Register(ProductCatalog, CustomerCatalog);
        }
    }
}