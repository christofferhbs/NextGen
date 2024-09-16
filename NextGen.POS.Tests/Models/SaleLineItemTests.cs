using NextGen.POS.Models;

namespace NextGen.POS.Tests.Models
{
    [TestFixture]
    internal class SalesLineItemTests
    {
        [Test]
        public void SalesLineItem_Constructor_ShouldSetProperties()
        {
            // Arrange
            var productDescription = new ProductDescription(1, 10.0, "Test Product");
            int quantity = 5;

            // Act
            var salesLineItem = new SalesLineItem(productDescription, quantity);

            // Assert
            Assert.AreEqual(productDescription, salesLineItem.ProductDescription);
            Assert.AreEqual(quantity, salesLineItem.Quantity);
        }

        [Test]
        public void GetSubtotal_ShouldReturnCorrectSubtotal()
        {
            // Arrange
            var productDescription = new ProductDescription(1, 10.0, "Test Product");
            int quantity = 5;
            var salesLineItem = new SalesLineItem(productDescription, quantity);

            // Act
            double subtotal = salesLineItem.GetSubtotal();

            // Assert
            Assert.AreEqual(50.0, subtotal);
        }
    }
}