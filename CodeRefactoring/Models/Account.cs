namespace CodeRefactoring.Models;

[Serializable]
public record Account(int AccountId, string Details, int LinkedId, int MarketId, bool NoBill, int Status, int SystemId, string Vatin)
{
    public Account() : this(0, string.Empty, 0, 0, false, 0, 0, string.Empty)
    {
    }
}
