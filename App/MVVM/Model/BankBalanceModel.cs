using App.Core;
using Common.Currency;
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

        public Euro CurrentBalance
        {
            get => ProcessImage.Instance.BankBalance.Amount;
            set
            {
                ProcessImage.Instance.BankBalance.Amount = value;
                OnPropertyChanged(nameof(CurrentBalance));
            }
        }

        private Transaction _selectedTransaction;

        public Transaction SelectedTransaction
        {
            get => _selectedTransaction;
            set => SetProperty(ref _selectedTransaction, value);
        }

        public List<Transaction> Transactions => ProcessImage.Instance.BankActivities.Values.ToList().OrderByDescending(x => x.Info.TransactionDate).ToList();

        public List<Transaction> ImportTransactions(string FilePath)
        {
            if (FilePath == null || FilePath == string.Empty) return new List<Transaction>();

            var importedBankAcitivities = new List<BankActivityInfo>(CsvParser.ParseBankActivities(FilePath));

            
            var processor = new BankActivityProcessor();

            var currentBankActivities = ProcessImage.Instance.BankActivities;
            var newTransactions = processor.AddToExistingDictionary(currentBankActivities, importedBankAcitivities);
            var bankBalanceChange = newTransactions.Sum(x => x.Info.TransactionVolume.Value);
            CurrentBalance = new Euro(CurrentBalance.Value + bankBalanceChange);
            return currentBankActivities.Values.ToList();
        }

        internal List<Transaction> DeletedEntries = new List<Transaction>();

        internal void DeleteEntry(Transaction theSelectedTransaction)
        {
            DeletedEntries.Add(theSelectedTransaction);
            CurrentBalance = new Euro(CurrentBalance.Value - theSelectedTransaction.Info.TransactionVolume.Value);
            ProcessImage.Instance.BankActivities.Remove(theSelectedTransaction.Info);
            OnPropertyChanged(nameof(Transactions));
        }

        internal void UndoDeleteEntry()
        {
            var lastDeletedEntry = DeletedEntries.Last();
            DeletedEntries.Remove(lastDeletedEntry);
            CurrentBalance = new Euro(CurrentBalance.Value + lastDeletedEntry.Info.TransactionVolume.Value);
            var transactionDictionary = ProcessImage.Instance.BankActivities;
            if (transactionDictionary.ContainsKey(lastDeletedEntry.Info))
            {
                return;
            }
            transactionDictionary.Add(lastDeletedEntry.Info, lastDeletedEntry);
            OnPropertyChanged(nameof(Transactions));
        }
    }
}
