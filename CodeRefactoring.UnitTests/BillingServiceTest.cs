using CodeRefactoring.Implementations;
using CodeRefactoring.Interfaces;
using CodeRefactoring.Models;
using Moq;
using System.Data;
using System.Data.Common;

namespace CodeRefactoring.UnitTests;

[TestClass]
public class BillingServiceTest
{
    [DataTestMethod]
    [DataRow(1)]
    [DataRow(2)]
    [DataRow(3)]
    public void TestFullNameForAwesomeCoReseller(int systemId)
    {
        //Arrange
        var connectionStringProvider = new Mock<IConnectionStringProvider>();
        var readerMock = CreateMockDbReader();
        var commandMock = CreateMockDbCommand(readerMock);
        var dbConnectionMock = CreateDbConnectionMock(commandMock);
        var factoryMock = CreateDbConnectionFactoryMock(dbConnectionMock);
        var billingContactDetailsReader = new BillingContactDetailsReader();
        var billingService = new BillingService(connectionStringProvider.Object, factoryMock.Object, billingContactDetailsReader);
        var expectedFullName = systemId == 2 ? Helpers.CreateFullName(TestHelper.firstName, TestHelper.lastName) : TestHelper.fullName;

        //Act
        var result = billingService.GetBillingContactDetails(new Account { SystemId = systemId, LinkedId = 1 });
        var actualFullName = result.BillingContactDetails.FullName;

        //Assert
        Assert.IsNotNull(result.GetBillingContactDetailsResponse);
        Assert.AreEqual(result.GetBillingContactDetailsResponse.ResponseType, ResponseType.Success);
        Assert.AreEqual(actualFullName, expectedFullName);
    }

    private static Mock<Func<IDbConnection>> CreateDbConnectionFactoryMock(Mock<IDbConnection> dbConnectionMock)
    {
        var factoryMock = new Mock<Func<IDbConnection>>();
        factoryMock.Setup(factory => factory.Invoke()).Returns(dbConnectionMock.Object);
        return factoryMock;
    }

    private static Mock<IDbConnection> CreateDbConnectionMock(Mock<IDbCommand> commandMock)
    {
        var dbConnectionMock = new Mock<IDbConnection>();
        dbConnectionMock.Setup(connection => connection.CreateCommand()).Returns(commandMock.Object);
        return dbConnectionMock;
    }

    private static Mock<IDbCommand> CreateMockDbCommand(Mock<DbDataReader> readerMock)
    {
        var commandMock = new Mock<IDbCommand>();
        var parameterMock = new Mock<IDbDataParameter>();
        var paramsMock = new Mock<IDataParameterCollection>();

        commandMock.Setup(x => x.ExecuteReader()).Returns(readerMock.Object);
        commandMock.Setup(x => x.CreateParameter()).Returns(parameterMock.Object);
        commandMock.Setup(x => x.Parameters).Returns(paramsMock.Object);
        return commandMock;
    }

    private static Mock<DbDataReader> CreateMockDbReader()
    {
        var readerMock = new Mock<DbDataReader>();
        readerMock.Setup(reader => reader["fullname"]).Returns(TestHelper.fullName);
        readerMock.Setup(reader => reader["addr1"]).Returns("Address1");
        readerMock.Setup(reader => reader["addr2"]).Returns("Address2");
        readerMock.Setup(reader => reader["addr3"]).Returns("Address3");
        readerMock.Setup(reader => reader["town"]).Returns("Erode");
        readerMock.Setup(reader => reader["iso"]).Returns("ISO");
        readerMock.Setup(reader => reader["first"]).Returns(TestHelper.firstName);
        readerMock.Setup(reader => reader["last"]).Returns(TestHelper.lastName);
        readerMock.SetupSequence(_ => _.Read()).Returns(true);
        return readerMock;
    }
}
