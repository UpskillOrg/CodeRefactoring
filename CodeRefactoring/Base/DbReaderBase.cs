using CodeRefactoring.Extentions;
using System.Data;

namespace CodeRefactoring.Base;

public abstract class DbReaderBase
{
    protected IDbCommand Create(IDbConnection billingDetailsDbConnection, string storedProcedureName, string parameterName, int parameterValue)
    {
        IDbCommand billingDetailsCommand = billingDetailsDbConnection.CreateCommand();
        billingDetailsCommand.CommandType = CommandType.StoredProcedure;
        billingDetailsCommand.CommandText = storedProcedureName;
        billingDetailsCommand.Connection = billingDetailsDbConnection;
        billingDetailsCommand.AddWithValue(parameterName, parameterValue);
        return billingDetailsCommand;
    }
}