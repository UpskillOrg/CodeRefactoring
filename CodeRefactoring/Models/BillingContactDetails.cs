namespace CodeRefactoring.Models;

public record struct BillingContactDetails(string Address1, string Address2, string Address3, string Town, int CountryId, string FullName, string TwoLetterCountry);
