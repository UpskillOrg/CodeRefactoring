namespace CodeRefactoring;

public static class Helpers
{
    public const string FullName = "fullname";
    public const string FirstName = "first";
    public const string LastName = "last";
    public const string Address1 = "addr1";
    public const string Address2 = "addr2";
    public const string Address3 = "addr3";    
    public const string Town = "town";
    public const string TwoLetterCountry = "iso";

    public const string AccountForIdStoredProcName = "AccountForId";
    public const string AccountForIdParamName = "@theid";
    public const string ResellerAccountForIdStoredProcName = "ResellerAccountForId";
    public const string ResellerAccountForIdParamName = "@reseller";


    public static string CreateFullName(string? firstName, string? lastName)
    {
        return Convert.ToString(firstName + " " + lastName);
    }    
}
