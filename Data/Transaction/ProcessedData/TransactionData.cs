using Common.Currency;
using Data.BankAtivity.Enums;

namespace Data.ProcessedData
{

    [Serializable]
    public class TransactionData
    {
        public Euro Amount { get; set; }

        public string Name { get; set; }

        public string MainCategory { get; set; }

        public string SubCategory { get; set; }

        public DateTime Date { get; set; }

        public Necessity Necessity { get; set; }

        public RegularityInterval Regularity { get; set; }
    }
}
