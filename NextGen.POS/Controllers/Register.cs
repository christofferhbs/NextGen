using NextGen.POS.Models;
using NextGen.POS.Services;

namespace NextGen.POS.Controllers
{
    public class Register
    {
        private ProductCatalog _productCatalog;
        private CustomerCatalog _customerCatalog;
        private Sale _currentSale;
        private Moms _moms;

        public Register(ProductCatalog productCatalog, CustomerCatalog customerCatalog)
        {
            _productCatalog = productCatalog;
            _customerCatalog = customerCatalog;
            _moms = new Moms(0.25);

        }

        public void EndSale()
        {
            _currentSale.BecomeComplete();
        }

        public void EnterItem(int id, int quantity)
        {
            ProductDescription desc = _productCatalog.GetProductDescription(id);

            _currentSale.MakeLineItem(desc, quantity);
        }

        public void MakeNewSale(CustomerDescription customerDescription)
        {
            _currentSale = new Sale(customerDescription, _moms);
        }

        public void MakePayment(double cashTendered)
        {
            _currentSale.MakePayment(cashTendered);
        }

        public CustomerDescription FindCustomer(int cno)
        {
            return _customerCatalog.GetCustomerDescription(cno);
        }

        public void Print()
        {
            Console.WriteLine("Bill:");
            Console.WriteLine("====================================");
            Console.WriteLine($"Kundenummer: {_currentSale.CustomerDescription.Kundenummer}");
            Console.WriteLine($"Kundenavn: {_currentSale.CustomerDescription.Navn}");
            Console.WriteLine($"Rabatsats: {_currentSale.CustomerDescription.Rabatsats}");
            Console.WriteLine("====================================");
            foreach (var item in _currentSale.LineItems)
            {
                Console.WriteLine($"{item.ProductDescription.Description} x{item.Quantity} @ {item.ProductDescription.Price:C} = {item.GetSubtotal():C}");
            }
            Console.WriteLine("====================================");
            Console.WriteLine($"Total: {_currentSale.GetTotal():C}");
            Console.WriteLine($"Discount: {_currentSale.GetDiscountAmount():C}");
            Console.WriteLine($"Total with discount: {_currentSale.GetTotalWithDiscount():C}");
            Console.WriteLine($"Moms: {_currentSale.GetMoms():C}");
            Console.WriteLine($"Total with Moms: {_currentSale.GetTotalWithMoms():C}");
            Console.WriteLine($"Payment: {_currentSale.Payment.Amount:C}");
            Console.WriteLine($"Balance: {_currentSale.Balance:C}");
            Console.WriteLine("====================================");
        }
    }
}
