using Data.InputData;
using Data.ProcessedData;

namespace Data.DataProcessor
{
    public class BankActivityProcessor
    {
        public KeyValuePair<BankActivityInfo, ProcessedBankActivity> Process(BankActivityInfo rawBankActivity)
        {
            if (ProcessImage.Instance.BankActivities.ContainsKey(rawBankActivity))
            {
                return new KeyValuePair<BankActivityInfo, ProcessedBankActivity>(rawBankActivity, ProcessImage.Instance.BankActivities[rawBankActivity]);
            }

            return new KeyValuePair<BankActivityInfo, ProcessedBankActivity>(rawBankActivity, new ProcessedBankActivity());
        }

        public IDictionary<BankActivityInfo, ProcessedBankActivity> AddToExistingDictionary(IDictionary<BankActivityInfo, ProcessedBankActivity> existingDictionary,
            List<BankActivityInfo> rawBankActivities)
        {
            foreach (var rawBankActivity in rawBankActivities)
            {
                var dictionaryEntry = Process(rawBankActivity);
                existingDictionary.Add(dictionaryEntry);
            }

            return existingDictionary;
        }
    }
}
