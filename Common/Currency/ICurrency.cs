namespace Common.Currency
{
    public interface ICurrency
    {
        string Symbol { get; }

        string Name { get; }

        string Abbreviation { get; }

        double Value { get; set; }
    }
}
