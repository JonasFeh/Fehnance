using Data.BankAtivity;
using Data.InputData;

namespace Data.DataProcessor
{
    public class TransactionProcessor
    {

        private TransactionFactory bankActivityFactory = new TransactionFactory();

        public KeyValuePair<TransactionInfo, Transaction> Process(IDictionary<TransactionInfo, Transaction> bankActivities, TransactionInfo rawBankActivity)
        {
            return new KeyValuePair<TransactionInfo, Transaction>(rawBankActivity, bankActivityFactory.Create(bankActivities, rawBankActivity));
        }

        public List<Transaction> AddToExistingDictionary(IDictionary<TransactionInfo,
            Transaction> existingDictionary, List<TransactionInfo> rawBankActivities)
        {
            var result = new List<Transaction>();
            foreach (var rawBankActivity in rawBankActivities)
            {
                if (rawBankActivity == null) continue;

                if (!existingDictionary.ContainsKey(rawBankActivity))
                {
                    var dictionaryEntry = Process(existingDictionary, rawBankActivity);
                    existingDictionary.Add(dictionaryEntry);
                    result.Add(dictionaryEntry.Value);
                }
            }

            return result;
        }
    }
}
