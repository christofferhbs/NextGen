using NextGen.POS.Models;

namespace NextGen.POS.Tests.Models
{
    [TestFixture]
    internal class ProductDescriptionTests
    {
        [Test]
        public void ProductDescription_Constructor_ShouldSetProperties()
        {
            // Arrange
            int id = 1;
            double price = 10.0;
            string description = "Test Product";

            // Act
            var productDescription = new ProductDescription(id, price, description);

            // Assert
            Assert.AreEqual(id, productDescription.Id);
            Assert.AreEqual(price, productDescription.Price);
            Assert.AreEqual(description, productDescription.Description);
        }
    }
}