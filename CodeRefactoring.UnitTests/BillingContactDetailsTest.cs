using CodeRefactoring.Models;

namespace CodeRefactoring.UnitTests;

[TestClass]
public class BillingContactDetailsTest
{
    [TestMethod]
    public void TestRecordStructType()
    {
        // Arrange
        var details = new BillingContactDetails("123 Main Street", "Apt 4", "", "New York", 1, "John Doe", "US");

        // Act
        var type = details.GetType();

        // Assert
        Assert.IsTrue(type.IsValueType);
    }
}
