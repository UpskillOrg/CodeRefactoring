using System.Data;
using CodeRefactoring.Models;

namespace CodeRefactoring.Interfaces;

public interface IBillingContactDetailsReader
{        
    BillingContactDetails GetBillingContactDetailsForAwesomeCoSellers(IDbConnection billingDetailsCommand, int linkedId);
    BillingContactDetails GetBillingContactDetailsForForAwesomeCoReseller(IDbConnection billingDetailsCommand, int linkedId);
}