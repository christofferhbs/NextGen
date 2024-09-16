// File: NextGen.POS.Tests/Models/StoreTests.cs

using NextGen.POS.Controllers;
using NextGen.POS.Models;

namespace NextGen.POS.Tests.Models
{
    [TestFixture]
    public class StoreTests
    {
        [Test]
        public void Store_Constructor_ShouldInitializeCustomerCatalog()
        {
            // Arrange & Act
            Store store = new Store();

            // Assert
            Assert.IsNotNull(store.CustomerCatalog);
        }

        [Test]
        public void Store_Register_ShouldHaveCustomerCatalog()
        {
            // Arrange
            Store store = new Store();

            // Act
            Register register = store.Register;

            // Assert
            Assert.AreEqual(store.CustomerCatalog, register.GetType().GetField("_customerCatalog", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(register));
        }
    }
}