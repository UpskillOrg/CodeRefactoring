using CodeRefactoring.Models;

namespace CodeRefactoring.Interfaces;

public interface IBillingContactDetailsResult
{
    BillingContactDetails BillingContactDetails { get; set; }
    GetBillingContactDetailsResponse? GetBillingContactDetailsResponse { get; set; }
}