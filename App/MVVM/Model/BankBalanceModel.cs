using App.Core;
using Data;
using Data.BankAtivity;
using Data.DataProcessor;
using Data.InputData;
using Data.Parser;
using System.Collections.Generic;
using System.Linq;

namespace App.MVVM.Model
{
    public class BankBalanceModel : ModelBase
    {
        public override void OnStartup()
        {
        }
        public IList<Transaction> Transactions => ProcessImage.Instance.BankActivities.Values.ToList();
        public IList<Transaction> ImportTransactions(string FilePath)
        {
            if (FilePath == null || FilePath == string.Empty) return new List<Transaction>();

            var importedBankAcitivities = new List<BankActivityInfo>(CsvParser.ParseBankActivities(FilePath));

            var processor = new BankActivityProcessor();

            var currentBankActivities = ProcessImage.Instance.BankActivities;
            processor.AddToExistingDictionary(currentBankActivities, importedBankAcitivities);
            return currentBankActivities.Values.ToList();
        }
    }
}
