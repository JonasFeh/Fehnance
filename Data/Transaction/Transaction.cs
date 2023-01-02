using Data.InputData;
using Data.ProcessedData;

namespace Data.BankAtivity
{
    [Serializable]
    public class Transaction
    {
        public TransactionInfo Info { get; set; } = new TransactionInfo();

        public TransactionData Data { get; set; } = new TransactionData();
    }
}
