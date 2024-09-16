using NextGen.POS.Controllers;
using NextGen.POS.Models;

namespace NextGen.POS
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a store
            Store store = new Store();

            // Get the register from the store
            Register register = store.Register;

            // Start a new sale
            register.MakeNewSale(register.FindCustomer(100));

            // Enter items into the sale
            register.EnterItem(100, 2); // Enter 2 units of product with ID 100
            register.EnterItem(200, 1); // Enter 1 unit of product with ID 200

            // End the sale
            register.EndSale();

            // Make a payment
            register.MakePayment(10.0); // Customer pays $10.00

            // Print the bill
            register.Print();
        }
    }
}