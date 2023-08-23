using System.Data;

namespace CodeRefactoring.Others;

public class BillingContext : IBillingContext
{
    #region Private Members
    private readonly IDbConnection _connection;
    private readonly IDbConnection? _systemDbConnection;
    #endregion

    #region Contructor
    public BillingContext(IDbConnection DBConn)
    {
        _connection = DBConn;
    }
    #endregion

    #region Constructor
    public BillingContext(IDbConnection DBConn, IDbConnection SystemDbConn)
    {
        _connection = DBConn;
        _systemDbConnection = SystemDbConn;
    }
    #endregion

    #region Public Properties
    public IDbTransaction? DbTransaction { get; set; }
    #endregion

    #region Internal Properties
    internal IDbConnection? Connection
    {
        get { return _connection; }
    }

    internal IDbConnection? SystemDbConnection
    {
        get { return _systemDbConnection; }
    }
    #endregion
}
