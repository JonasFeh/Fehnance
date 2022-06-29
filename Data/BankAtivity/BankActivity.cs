using Data.InputData;
using Data.ProcessedData;

namespace Data.BankAtivity
{
    [Serializable]
    public class BankActivity
    {
        public BankActivityInfo Info { get; set; } = new BankActivityInfo();

        public BankActivityDataBase Data { get; set; } = new BankActivityData();
    }
}
