using NextGen.POS.Services;

namespace NextGen.POS.Tests.Services
{
    [TestFixture]
    internal class PaymentTests
    {
        [Test]
        public void Payment_Constructor_ShouldSetAmount()
        {
            // Arrange
            double cashTendered = 50.0;

            // Act
            Payment payment = new Payment(cashTendered);

            // Assert
            Assert.AreEqual(cashTendered, payment.Amount);
        }
    }
}