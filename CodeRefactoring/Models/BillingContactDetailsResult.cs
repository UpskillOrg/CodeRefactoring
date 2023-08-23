using CodeRefactoring.Interfaces;

namespace CodeRefactoring.Models;

public class BillingContactDetailsResult : IBillingContactDetailsResult
{
    public BillingContactDetails BillingContactDetails { get; set; }

    public GetBillingContactDetailsResponse? GetBillingContactDetailsResponse { get; set; }
}
