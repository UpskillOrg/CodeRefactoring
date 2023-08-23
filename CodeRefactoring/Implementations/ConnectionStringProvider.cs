using System.Configuration;
using CodeRefactoring.Interfaces;

namespace CodeRefactoring.Implementations;

public class ConnectionStringProvider : IConnectionStringProvider
{
    public string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["AwesomeCo"].ConnectionString;
    }
}
