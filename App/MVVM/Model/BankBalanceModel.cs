using App.Core;
using Common.Currency;
using Data;
using Data.BankAtivity;
using Data.DataProcessor;
using Data.InputData;
using Data.Parser;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.MVVM.Model
{
    public class BankBalanceModel : ModelBase
    {
        public override void OnStartup()
        {
        }

        public Euro CurrentBalance 
        {
            get => ProcessImage.Instance.BankBalance.Amount;
            set => ProcessImage.Instance.BankBalance.Amount = value; 
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
