using System.Data;
using CodeRefactoring.Base;
using CodeRefactoring.Interfaces;
using CodeRefactoring.Models;

namespace CodeRefactoring.Implementations;

public class BillingContactDetailsReader : DbReaderBase, IBillingContactDetailsReader
{
    private BillingContactDetails GetBillingContactDetails(IDataReader reader)
    {
        BillingContactDetails billingContactDetails = new();
        if (reader != null)
        {
            billingContactDetails.Address1 = reader[Helpers.Address1]?.ToString() ?? string.Empty;
            billingContactDetails.Address2 = reader[Helpers.Address2].ToString() ?? string.Empty;
            billingContactDetails.Town = reader[Helpers.Town].ToString() ?? string.Empty;
            billingContactDetails.TwoLetterCountry = reader[Helpers.TwoLetterCountry].ToString() ?? string.Empty;
        }

        return billingContactDetails;
    }

    public BillingContactDetails GetBillingContactDetailsForAwesomeCoSellers(IDbConnection billingDetailsDbConnection, int linkedId)
    {
        BillingContactDetails billingContactDetails = default;
        IDataReader? reader = default;
        try
        {
            using var billingDetailsCommand = Create(billingDetailsDbConnection, Helpers.AccountForIdStoredProcName, Helpers.AccountForIdParamName, linkedId);
            reader = billingDetailsCommand.ExecuteReader();
            if (reader != null && reader.Read())
            {
                billingContactDetails = GetBillingContactDetails(reader);
                billingContactDetails.FullName = (reader[Helpers.FullName].ToString() ?? string.Empty).Trim();
                billingContactDetails.Address3 = reader[Helpers.Address3].ToString() ?? string.Empty;
            }
        }
        finally
        {
            reader?.Close();
        }
        return billingContactDetails;
    }

    public BillingContactDetails GetBillingContactDetailsForForAwesomeCoReseller(IDbConnection billingDetailsDbConnection, int linkedId)
    {
        BillingContactDetails billingContactDetails = default;
        IDataReader? reader = default;
        try
        {
            using var billingDetailsCommand = Create(billingDetailsDbConnection, Helpers.ResellerAccountForIdStoredProcName, Helpers.ResellerAccountForIdParamName, linkedId);
            reader = billingDetailsCommand.ExecuteReader();
            if (reader != null && reader.Read())
            {
                billingContactDetails = GetBillingContactDetails(reader);
                billingContactDetails.FullName = Helpers.CreateFullName(Convert.ToString(reader[Helpers.FirstName] ?? string.Empty), Convert.ToString(reader[Helpers.LastName] ?? string.Empty));
                billingContactDetails.Address3 = "";
            }
        }
        finally
        {
            reader?.Close();
        }
        return billingContactDetails;
    }
}
