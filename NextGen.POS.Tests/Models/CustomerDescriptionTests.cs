// File: NextGen.POS.Tests/Models/CustomerDescriptionTests.cs
using NextGen.POS.Models;

namespace NextGen.POS.Tests.Models
{
    [TestFixture]
    public class CustomerDescriptionTests
    {
        [Test]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            int kundenummer = 100;
            string navn = "Navn Et";
            double rabatsats = 10;

            // Act
            var customerDescription = new CustomerDescription(kundenummer, navn, rabatsats);

            // Assert
            Assert.AreEqual(kundenummer, customerDescription.Kundenummer);
            Assert.AreEqual(navn, customerDescription.Navn);
            Assert.AreEqual(rabatsats, customerDescription.Rabatsats);
        }
    }
}