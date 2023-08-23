using CodeRefactoring.Models;

namespace CodeRefactoring.Interfaces;

public interface IBillingService
{
    BillingContactDetailsResult GetBillingContactDetails(Account account);
}