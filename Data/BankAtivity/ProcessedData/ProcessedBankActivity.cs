using Common.Currency;
using Data.BankAtivity.ProcessedData;

namespace Data.ProcessedData
{

    [Serializable]
    public class ProcessedBankActivity
    {
        public Euro Amount { get; set; }

        public Category Category { get; set; }

        public DateTime Date { get; set; }

        public BankActivityType Type { get; set; }

        public Regularity Regularity { get; set; }
    }
}
