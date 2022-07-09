using Data.InputData;
using Data.ProcessedData;

namespace Data.BankAtivity
{
    [Serializable]
    public class Transaction
    {
        public BankActivityInfo Info { get; set; } = new BankActivityInfo();

        public BankActivityData Data { get; set; } = new BankActivityData();
    }
}
