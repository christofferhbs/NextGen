// File: NextGen.POS.Tests/Services/SaleTests.cs
using NextGen.POS.Models;
using NextGen.POS.Services;

namespace NextGen.POS.Tests.Services
{
    [TestFixture]
    public class SaleTests
    {
        [Test]
        public void GetTotalWithDiscount_ShouldReturnCorrectTotalWithDiscount()
        {
            // Arrange
            var customerDescription = new CustomerDescription(100, "Navn 1", 0.1); // 10% discount
            var moms = new Moms(0.25); // Assuming 25% tax rate
            var sale = new Sale(customerDescription, moms);
            var productDescription = new ProductDescription(1, 100.0, "Product 1");
            sale.MakeLineItem(productDescription, 2);

            // Act
            var totalWithDiscount = sale.GetTotalWithDiscount();

            // Assert
            Assert.That(totalWithDiscount, Is.EqualTo(180.0)); // 200 - 20 (10% of 200)
        }

        [Test]
        public void GetDiscountAmount_ShouldReturnCorrectDiscountAmount()
        {
            // Arrange
            var customerDescription = new CustomerDescription(100, "Navn 1", 0.1); // 10% discount
            var moms = new Moms(0.25); // Assuming 25% tax rate
            var sale = new Sale(customerDescription, moms);
            var productDescription = new ProductDescription(1, 100.0, "Product 1");
            sale.MakeLineItem(productDescription, 2);

            // Act
            var discountAmount = sale.GetDiscountAmount();

            // Assert
            Assert.That(discountAmount, Is.EqualTo(20.0)); // 10% of 200
        }
    }
}