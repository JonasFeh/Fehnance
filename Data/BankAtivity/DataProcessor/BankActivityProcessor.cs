using Data.BankAtivity;
using Data.InputData;

namespace Data.DataProcessor
{
    public class BankActivityProcessor
    {

        private BankActivityFactory bankActivityFactory = new BankActivityFactory();

        public KeyValuePair<BankActivityInfo, BankActivity> Process(IDictionary<BankActivityInfo, BankActivity> bankActivities, BankActivityInfo rawBankActivity)
        {
            return new KeyValuePair<BankActivityInfo, BankActivity>(rawBankActivity, bankActivityFactory.Create(bankActivities, rawBankActivity));
        }

        public IDictionary<BankActivityInfo, BankActivity> AddToExistingDictionary(IDictionary<BankActivityInfo,
            BankActivity> existingDictionary, List<BankActivityInfo> rawBankActivities)
        {
            foreach (var rawBankActivity in rawBankActivities)
            {
                var dictionaryEntry = Process(existingDictionary, rawBankActivity);
                existingDictionary.Add(dictionaryEntry);
            }

            return existingDictionary;
        }
    }
}
