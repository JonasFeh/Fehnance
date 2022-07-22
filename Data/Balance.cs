using Common.Currency;

namespace Data
{
    [Serializable]
    public class Balance
    {
        public Euro Amount { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
