using NextGen.POS.Controllers;

namespace NextGen.POS.Models
{
    public class Store
    {
        private ProductCatalog _productCatalog = new ProductCatalog();
        private CustomerCatalog _customerCatalog = new CustomerCatalog();
        private Register _register;

        public ProductCatalog ProductCatalog { get { return _productCatalog; } }
        public CustomerCatalog CustomerCatalog { get { return _customerCatalog; } }
        public Register Register { get { return _register; } }

        public Store()
        {
            _register = new Register(_productCatalog, _customerCatalog);
        }
    }
}
