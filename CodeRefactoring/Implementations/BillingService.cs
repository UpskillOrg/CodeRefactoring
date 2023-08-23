using System.Data;
using CodeRefactoring.Exceptions;
using CodeRefactoring.Interfaces;
using CodeRefactoring.Models;

namespace CodeRefactoring.Implementations;

public class BillingService : IBillingService
{
    private Func<IDbConnection> Factory { get; }
    private IConnectionStringProvider? ConnectionStringProvider { get; set; }
    private IBillingContactDetailsReader? BillingContactDetailsReader { get; set; }

    public BillingService(IConnectionStringProvider connectionStringProvider, Func<IDbConnection> factory, IBillingContactDetailsReader billingContactDetailsReader)
    {
        Factory = factory;
        ConnectionStringProvider = connectionStringProvider;
        BillingContactDetailsReader = billingContactDetailsReader;
    }

    public BillingContactDetailsResult GetBillingContactDetails(Account account)
    {
        BillingContactDetails billingContactDetails = default;
        GetBillingContactDetailsResponse? response;

        try
        {
            using IDbConnection billingDetailsDbConnection = Factory.Invoke();
            billingDetailsDbConnection.ConnectionString = ConnectionStringProvider?.GetConnectionString();

            billingDetailsDbConnection.Open();

            if (BillingContactDetailsReader != null)
            {
                switch (account.SystemId)
                {
                    case 3:
                    case 1:                                                                                                                                                     
                        billingContactDetails = BillingContactDetailsReader.GetBillingContactDetailsForAwesomeCoSellers(billingDetailsDbConnection, account.LinkedId);

                        break;
                    case 2:
                        billingContactDetails = BillingContactDetailsReader.GetBillingContactDetailsForForAwesomeCoReseller(billingDetailsDbConnection, account.LinkedId);
                        break;
                    default:
                        throw new UnknownSystemException();
                }
            }

            billingDetailsDbConnection.Close();
        }
        catch (Exception ex)
        {
            response = new GetBillingContactDetailsResponse(ex.Message, ResponseType.Error);
        }

        response = new GetBillingContactDetailsResponse("Completed", ResponseType.Success);

        return new BillingContactDetailsResult { BillingContactDetails = billingContactDetails, GetBillingContactDetailsResponse = response };
    }
}
