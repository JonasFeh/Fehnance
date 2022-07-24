using Data.BankAtivity;
using Data.InputData;

namespace Data.DataProcessor
{
    public class BankActivityProcessor
    {

        private BankActivityFactory bankActivityFactory = new BankActivityFactory();

        public KeyValuePair<BankActivityInfo, Transaction> Process(IDictionary<BankActivityInfo, Transaction> bankActivities, BankActivityInfo rawBankActivity)
        {
            return new KeyValuePair<BankActivityInfo, Transaction>(rawBankActivity, bankActivityFactory.Create(bankActivities, rawBankActivity));
        }

        public List<Transaction> AddToExistingDictionary(IDictionary<BankActivityInfo,
            Transaction> existingDictionary, List<BankActivityInfo> rawBankActivities)
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
