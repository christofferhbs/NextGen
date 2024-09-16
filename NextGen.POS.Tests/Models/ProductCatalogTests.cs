using NextGen.POS.Models;

[TestFixture]
internal class ProductCatalogTests
{
    [Test]
    public void ProductCatalog_Constructor_ShouldInitializeDescriptions()
    {
        // Arrange & Act
        var catalog = new ProductCatalog();

        // Assert
        Assert.IsNotNull(catalog.GetProductDescription(100));
        Assert.IsNotNull(catalog.GetProductDescription(200));
    }

    [Test]
    public void GetProductDescription_ShouldReturnCorrectDescription()
    {
        // Arrange
        var catalog = new ProductCatalog();

        // Act
        var description = catalog.GetProductDescription(100);

        // Assert
        Assert.IsNotNull(description);
        Assert.AreEqual(100, description.Id);
        Assert.AreEqual(3, description.Price);
        Assert.AreEqual("product 1", description.Description);
    }

    [Test]
    public void GetProductDescription_ShouldReturnNullForInvalidId()
    {
        // Arrange
        var catalog = new ProductCatalog();

        // Act
        var description = catalog.GetProductDescription(999);

        // Assert
        Assert.IsNull(description);
    }
}