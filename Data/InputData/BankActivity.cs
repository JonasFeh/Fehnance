using Common.Currency;

namespace Data.InputData
{
    [Serializable]
    public class BankActivity : InputDataBase
    {
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public string BankAccountIban { get; set; } = "";

        public Euro TransactionVolume { get; set; } = new Euro(0.0);

        public string TransactionType { get; set; } = "";

        public string Description { get; set; } = "";

        public string CreditorIban { get; set; } = "";

        public string Creditor { get; set; } = "";

        public string CreditorSwift { get; set; } = "";

    }
}
