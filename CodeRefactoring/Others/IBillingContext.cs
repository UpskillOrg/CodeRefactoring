using System.Data;

namespace CodeRefactoring.Others;

public interface IBillingContext
{
    IDbTransaction? DbTransaction { get; set; }
}