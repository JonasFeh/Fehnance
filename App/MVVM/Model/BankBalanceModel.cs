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

        public IDictionary<BankActivityInfo, ProcessedBankActivity> ImportBankActivities(string FilePath)
        {
            if (FilePath == null || FilePath == string.Empty) return new Dictionary<BankActivityInfo, ProcessedBankActivity>();

            var importedBankAcitivities = new List<BankActivityInfo>(CsvParser.ParseBankActivities(FilePath));

            var processor = new BankActivityProcessor();

            var currentBankActivities = ProcessImage.Instance.BankActivities;
            processor.AddToExistingDictionary(currentBankActivities, importedBankAcitivities);

            return currentBankActivities;
        }
    }
}
