// File: NextGen.POS.Tests/Controllers/RegisterTests.cs
using NextGen.POS.Controllers;
using NextGen.POS.Models;
using NextGen.POS.Services;

namespace NextGen.POS.Tests.Controllers
{
    [TestFixture]
    public class RegisterTests
    {
        private Register _register;
        private ProductCatalog _productCatalog;
        private CustomerCatalog _customerCatalog;

        [SetUp]
        public void Setup()
        {
            _productCatalog = new ProductCatalog();
            _customerCatalog = new CustomerCatalog();
            _register = new Register(_productCatalog, _customerCatalog);
        }

        [Test]
        public void MakeNewSale_ShouldInitializeCurrentSale()
        {
            // Arrange
            var customerDescription = new CustomerDescription(100, "Navn 1", 0.1);

            // Act
            _register.MakeNewSale(customerDescription);

            // Assert
            Assert.IsNotNull(_register.GetType().GetField("_currentSale", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(_register));
        }

        [Test]
        public void EnterItem_ShouldAddLineItemToCurrentSale()
        {
            // Arrange
            var customerDescription = new CustomerDescription(100, "Navn 1", 0.1);
            _register.MakeNewSale(customerDescription);

            // Act
            _register.EnterItem(1, 2);

            // Assert
            var currentSale = (Sale)_register.GetType().GetField("_currentSale", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(_register);
            Assert.AreEqual(1, currentSale.LineItems.Count);
            Assert.AreEqual(2, currentSale.LineItems[0].Quantity);
        }

        [Test]
        public void EndSale_ShouldMarkSaleAsComplete()
        {
            // Arrange
            var customerDescription = new CustomerDescription(100, "Navn 1", 0.1);
            _register.MakeNewSale(customerDescription);

            // Act
            _register.EndSale();

            // Assert
            var currentSale = (Sale)_register.GetType().GetField("_currentSale", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(_register);
            Assert.IsTrue(currentSale.IsComplete);
        }

        [Test]
        public void MakePayment_ShouldSetPaymentForCurrentSale()
        {
            // Arrange
            var customerDescription = new CustomerDescription(100, "Navn 1", 0.1);
            _register.MakeNewSale(customerDescription);

            // Act
            _register.MakePayment(200.0);

            // Assert
            var currentSale = (Sale)_register.GetType().GetField("_currentSale", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(_register);
            Assert.AreEqual(200.0, currentSale.Payment.Amount);
        }

        [Test]
        public void FindCustomer_ShouldReturnCorrectCustomerDescription()
        {
            // Act
            var customer = _register.FindCustomer(100);

            // Assert
            Assert.IsNotNull(customer);
            Assert.AreEqual(100, customer.Kundenummer);
            Assert.AreEqual("Navn Et", customer.Navn);
            Assert.AreEqual(10, customer.Rabatsats);
        }
    }
}