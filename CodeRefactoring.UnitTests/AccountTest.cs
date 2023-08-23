using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Principal;
using System.Xml.Serialization;
using CodeRefactoring.Models;

namespace CodeRefactoring.UnitTests;

[TestClass]
public class AccountTest
{
    [TestMethod]
    public void TestRecordSerialization()
    {
        // Arrange
        var account = new Account(1, "John Doe", 2, 3, false, 4, 5, "123456789");
        var serializer = new XmlSerializer(typeof(Account));
        var stream = new MemoryStream();

        // Act
        serializer.Serialize(stream, account); 
        stream.Position = 0;
        var deserializedAccount = serializer.Deserialize(stream) as Account;

        // Assert
        Assert.AreEqual(account, deserializedAccount); 
    }
}