using Data.InputData;
using Data.ProcessedData;
using System.Text;

namespace Data.BankAtivity
{
    public class BankActivityFactory
    {
        private String NormalizeName(string name)
        {
            name.Trim();
            char currentChar = char.MinValue;
            var normalizedName = new StringBuilder();
            foreach (var character in name)
            {
                if (char.IsWhiteSpace(character))
                {
                    if (!char.IsWhiteSpace(currentChar))
                    {
                        normalizedName.Append(character);
                        currentChar = character;
                    }
                }
                else
                {
                    normalizedName.Append(character);
                    currentChar = character;
                }
            }
            var result = normalizedName.ToString().Normalize();
            return result;
        }

        public Transaction Create(IDictionary<BankActivityInfo, Transaction> bankActivities, BankActivityInfo info)
        {
            if (bankActivities == null) throw new ArgumentNullException("Bank activities needed to construct bank acitivities!");

            if (info == null) throw new ArgumentNullException("Cannot construct a Bankactivity with no information!");

            if (!bankActivities.ContainsKey(info))
            {
                return new Transaction
                {
                    Info = info,
                    Data = new BankActivityData
                    {
                        Amount = info.TransactionVolume,
                        MainCategory = String.Empty,
                        SubCategory = String.Empty,
                        Date = info.TransactionDate,
                        Regularity = new ProcessedData.Regularity(),
                        Necessity = Enums.Necessity.Neutral,
                        Name = NormalizeName(info.Creditor),
                    }
                };
            }

            if (containsSimilarKey(bankActivities, info, out Transaction transaction))
            {
                return transaction;
            }

            return new Transaction
            {
                Info = info,
                Data = bankActivities[info].Data,
            };
        }

        private bool containsSimilarKey(IDictionary<BankActivityInfo, Transaction> bankActivities, BankActivityInfo info, out Transaction transaction)
        {
            foreach (var transactionInfo in bankActivities.Keys)
            {
                if (transactionInfo.CreditorIban == info.CreditorIban &&
                    transactionInfo.Creditor == info.Creditor &&
                    transactionInfo.CreditorSwift == info.CreditorSwift )
                {
                    transaction = bankActivities[transactionInfo];
                    return true;
                }
            }
            transaction = null;
            return false;
        }
    }
}
