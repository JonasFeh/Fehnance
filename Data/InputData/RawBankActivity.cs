using Common.Currency;
using System;

namespace Data.InputData
{
    [Serializable]
    public class RawBankActivity : InputDataBase, IEquatable<RawBankActivity>
    {
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public string BankAccountIban { get; set; } = "";

        public Euro TransactionVolume { get; set; } = new Euro(0.0);

        public string TransactionType { get; set; } = "";

        public string Description { get; set; } = "";

        public string CreditorIban { get; set; } = "";

        public string Creditor { get; set; } = "";

        public string CreditorSwift { get; set; } = "";

        /// <summary>
        /// Only give true if all properties are the same.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(RawBankActivity? other)
        {
            if (other == null) return false;

            return TransactionDate == other.TransactionDate &&
                BankAccountIban == other.BankAccountIban &&
                TransactionVolume.Equals(other.TransactionVolume) &&
                TransactionType == other.TransactionType &&
                Description == other.Description &&
                CreditorIban == other.CreditorIban &&
                Creditor == other.Creditor &&
                CreditorSwift == other.CreditorSwift;
        }
    }
}
