using App.Core;
using Data;
using Data.DataProcessor;
using Data.InputData;
using Data.Parser;
using Data.ProcessedData;
using System.Collections.Generic;

namespace App.MVVM.Model
{
    public class BankBalanceModel : ModelBase
    {

        public IDictionary<RawBankActivity, ProcessedBankActivity> ImportBankActivities(string FilePath)
        {
            if (FilePath == null || FilePath == string.Empty) return new Dictionary<RawBankActivity, ProcessedBankActivity>();

            var importedBankAcitivities = new List<RawBankActivity>(CsvParser.ParseBankActivities(FilePath));

            var processor = new BankActivityProcessor();

            var currentBankActivities = ProcessImage.Instance.BankActivities;
            processor.AddToExistingDictionary(currentBankActivities, importedBankAcitivities);

            return currentBankActivities;
        }
    }
}
