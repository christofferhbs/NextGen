using NextGen.POS.Models;
using NextGen.POS.Services;

namespace NextGen.POS.Controllers
{
    public class Register
    {
        private readonly ProductCatalog _productCatalog;
        private readonly CustomerCatalog _customerCatalog;
        private Sale _currentSale;
        private readonly Moms _moms;

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
            var desc = _productCatalog.GetProductDescription(id);
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
            var currentSale = _currentSale;
            var customerDescription = currentSale.CustomerDescription;

            Console.WriteLine("Faktura:");
            Console.WriteLine("====================================");
            Console.WriteLine($"Kundenummer: {customerDescription.Kundenummer}");
            Console.WriteLine($"Kundenavn: {customerDescription.Navn}");
            Console.WriteLine($"Rabatsats: {customerDescription.Rabatsats}");
            Console.WriteLine("====================================");

            foreach (var item in currentSale.LineItems)
            {
                Console.WriteLine($"{item.ProductDescription.Description} x{item.Quantity} @ {item.ProductDescription.Price:C} = {item.GetSubtotal():C}");
            }

            Console.WriteLine("====================================");
            Console.WriteLine($"Total: {currentSale.GetTotal():C}");
            Console.WriteLine($"Discount: {currentSale.GetDiscountAmount():C}");
            Console.WriteLine($"Total with discount: {currentSale.GetTotalWithDiscount():C}");
            Console.WriteLine($"Moms: {currentSale.GetMoms():C}");
            Console.WriteLine($"Total with Moms: {currentSale.GetTotalWithMoms():C}");
            Console.WriteLine($"Payment: {currentSale.Payment.Amount:C}");
            Console.WriteLine($"Balance: {currentSale.Balance:C}");
            Console.WriteLine("====================================");
        }
    }
}
