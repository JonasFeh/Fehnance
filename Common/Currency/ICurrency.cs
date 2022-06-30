namespace Common.Currency
{
    public interface ICurrency : IEquatable<ICurrency>
    {
        string Symbol { get; }

        string Name { get; }

        string Abbreviation { get; }

        decimal Value { get; set; }

        string DisplayValue { get; }
    }
}
