using Data.InputData;
using Data.ProcessedData;
using System.Text;

namespace Data.BankAtivity
{
    public class TransactionFactory
    {
        private string NormalizeName(string name)
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

        public Transaction Create(IDictionary<TransactionInfo, Transaction> bankActivities, TransactionInfo info)
        {
            if (bankActivities == null) throw new ArgumentNullException("Bank activities needed to construct bank activities!");

            if (info == null) throw new ArgumentNullException("Cannot construct a Bankactivity with no information!");

            if (bankActivities.ContainsKey(info))
            {
                return new Transaction
                {
                    Info = info,
                    Data = bankActivities[info].Data,
                };
            }

            if (containsSimilarKey(bankActivities, info, out Transaction transaction))
            {
                return transaction;
            }

            return new Transaction
            {
                Info = info,
                Data = new TransactionData
                {
                    Amount = info.TransactionVolume,
                    MainCategory = string.Empty,
                    SubCategory = string.Empty,
                    Date = info.TransactionDate,
                    Regularity = Enums.RegularityInterval.None,
                    Necessity = Enums.Necessity.Neutral,
                    Name = NormalizeName(info.Creditor),
                }
            };

        }

        private bool containsSimilarKey(IDictionary<TransactionInfo, Transaction> bankActivities, TransactionInfo info, out Transaction transaction)
        {
            transaction = null;

            foreach (var transactionInfo in bankActivities.Keys)
            {
                if (transactionInfo.CreditorIban == info.CreditorIban &&
                    transactionInfo.Creditor == info.Creditor &&
                    transactionInfo.CreditorSwift == info.CreditorSwift)
                {
                    var aSimilarTransactionData = bankActivities[transactionInfo].Data;
                    transaction = new Transaction
                    {
                        Info = info,
                        Data = new TransactionData
                        {
                            Amount = info.TransactionVolume,
                            Date = info.TransactionDate,
                            MainCategory = aSimilarTransactionData.MainCategory,
                            SubCategory = aSimilarTransactionData.SubCategory,
                            Name = aSimilarTransactionData.Name,
                            Necessity = aSimilarTransactionData.Necessity,
                            Regularity = aSimilarTransactionData.Regularity,
                        }
                    };
                    return true;
                }
            }
            return false;
        }
    }
}
