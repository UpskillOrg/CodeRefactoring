using System.Data;

namespace CodeRefactoring.Extentions;

public static class DbCommandExtensionMethods
{
    public static void AddWithValue(this IDbCommand command, string name, object value)
    {
        var parameter = command.CreateParameter();
        parameter.ParameterName = name;
        parameter.Value = value;
        command.Parameters.Add(parameter);
    }
}
