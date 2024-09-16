// File: NextGen.POS.Tests/Models/CustomerCatalogTests.cs
using NextGen.POS.Models;

namespace NextGen.POS.Tests.Models
{
    [TestFixture]
    public class CustomerCatalogTests
    {
        private CustomerCatalog _customerCatalog;

        [SetUp]
        public void Setup()
        {
            _customerCatalog = new CustomerCatalog();
        }

        [Test]
        public void Constructor_ShouldInitializeWithSampleData()
        {
            var customer100 = _customerCatalog.GetCustomerDescription(100);
            var customer200 = _customerCatalog.GetCustomerDescription(200);

            Assert.IsNotNull(customer100);
            Assert.AreEqual(100, customer100.Kundenummer);
            Assert.AreEqual("Navn Et", customer100.Navn);
            Assert.AreEqual(0.1, customer100.Rabatsats);

            Assert.IsNotNull(customer200);
            Assert.AreEqual(200, customer200.Kundenummer);
            Assert.AreEqual("Navn To", customer200.Navn);
            Assert.AreEqual(0.0, customer200.Rabatsats);
        }

        [Test]
        public void GetCustomerDescription_ShouldReturnCorrectCustomer()
        {
            var customer = _customerCatalog.GetCustomerDescription(100);

            Assert.IsNotNull(customer);
            Assert.AreEqual(100, customer.Kundenummer);
            Assert.AreEqual("Navn Et", customer.Navn);
            Assert.AreEqual(0.1, customer.Rabatsats);
        }

        [Test]
        public void GetCustomerDescription_ShouldReturnNullForNonExistentCustomer()
        {
            var customer = _customerCatalog.GetCustomerDescription(999);

            Assert.IsNull(customer);
        }
    }
}