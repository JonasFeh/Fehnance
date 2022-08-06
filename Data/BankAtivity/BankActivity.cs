using Data.InputData;
using Data.ProcessedData;

namespace Data.BankAtivity
{
    [Serializable]
    public class Transaction
    {
        public TransactionInfo Info { get; set; } = new TransactionInfo();

        public BankActivityData Data { get; set; } = new BankActivityData();
    }
}
