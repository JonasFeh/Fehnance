using Data.InputData;
using Data.ProcessedData;

namespace Data.DataProcessor
{
    public class BankActivityProcessor
    {
        public KeyValuePair<RawBankActivity, ProcessedBankActivity> Process(RawBankActivity rawBankActivity)
        {
            if (ProcessImage.Instance.BankActivities.ContainsKey(rawBankActivity))
            {
                return new KeyValuePair<RawBankActivity, ProcessedBankActivity>(rawBankActivity, ProcessImage.Instance.BankActivities[rawBankActivity]);
            }

            return new KeyValuePair<RawBankActivity, ProcessedBankActivity>(rawBankActivity, new ProcessedBankActivity());
        }

        public IDictionary<RawBankActivity, ProcessedBankActivity> AddToExistingDictionary(IDictionary<RawBankActivity, ProcessedBankActivity> existingDictionary,
            List<RawBankActivity> rawBankActivities)
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
