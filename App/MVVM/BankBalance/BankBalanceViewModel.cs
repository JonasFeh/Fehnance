using Common.Currency;
using Data.BankAtivity;
using Data.BankAtivity.Enums;
using FinanceOverviewApp.Core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace App.MVVM.BankBalance
{
    public class BankBalanceViewModel : ViewModelBase<BankBalanceModel>
    {

        protected override void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Model.CurrentBalance):
                    OnPropertyChanged(nameof(CurrentBalance));
                    OnPropertyChanged(nameof(BalanceDisplayValue));
                    break;
                case nameof(Model.Transactions):
                    OnPropertyChanged(nameof(CurrentBalance));
                    OnPropertyChanged(nameof(Transactions));
                    OnPropertyChanged(nameof(BalanceDisplayValue));
                    break;
                case nameof(Model.SelectedTransaction):
                    OnPropertyChanged(nameof(SelectedTransaction));
                    break;
                default:
                    break;
            }
        }
        public override void OnStartup()
        {
            _transactions = new ObservableCollection<Transaction>();
        }

        #region Bank balance

        private bool _IsBalanceEditing = false;

        public bool IsBalanceEditing
        {
            get => _IsBalanceEditing;
            set => SetProperty(ref _IsBalanceEditing, value);
        }

        public decimal CurrentBalance
        {
            get => Model.CurrentBalance.Value;
            set
            {
                Model.CurrentBalance = new Euro(value);
                OnPropertyChanged(nameof(BalanceDisplayValue));
            }
        }

        public string BalanceDisplayValue => CurrentBalance.ToString("C2");


        RelayCommand m_EditBalance;

        public ICommand EditBalance
        {
            get
            {
                if (m_EditBalance == null)
                {
                    m_EditBalance = new RelayCommand(m => IsBalanceEditing = true);
                }
                return m_EditBalance;
            }
        }

        RelayCommand m_FinishEditBalance;

        public ICommand FinishEditBalance
        {
            get
            {
                if (m_FinishEditBalance == null)
                {
                    m_FinishEditBalance = new RelayCommand(m => IsBalanceEditing = false);
                }
                return m_FinishEditBalance;
            }
        }

        #endregion

        #region Transactions

        private ObservableCollection<Transaction> _transactions;
        public ObservableCollection<Transaction> Transactions
        {
            get
            {
                _transactions = new ObservableCollection<Transaction>(Model.Transactions);
                return _transactions;
            }
            set => SetProperty(ref _transactions, value);
        }

        public Transaction SelectedTransaction
        {
            get => Model.SelectedTransaction;
            set => Model.SelectedTransaction = value;
        }

        private List<Transaction> _deletedEntries = new List<Transaction>();

        RelayCommand m_DeleteEntry;

        public ICommand DeleteEntry
        {
            get
            {
                if (m_DeleteEntry == null)
                {
                    m_DeleteEntry = new RelayCommand(m => deleteEntry());
                }
                return m_DeleteEntry;
            }
        }

        private void deleteEntry()
        {
            Model.DeleteEntry(SelectedTransaction);

            OnPropertyChanged(nameof(Transactions));
            OnPropertyChanged(nameof(SelectedTransaction));
        }

        RelayCommand m_UndoDeleteEntry;

        public ICommand UndoDeleteEntry
        {
            get
            {
                if (m_UndoDeleteEntry == null)
                {
                    m_UndoDeleteEntry = new RelayCommand(m => undoDeleteEntry());
                }
                return m_UndoDeleteEntry;
            }
        }


        private void undoDeleteEntry()
        {
            if (Model.DeletedEntries.Count == 0)
            {
                return;
            }

            Model.UndoDeleteEntry();

            OnPropertyChanged(nameof(Transactions));
            OnPropertyChanged(nameof(SelectedTransaction));
        }

        private decimal changeCurrentBalance(decimal theAmount)
        {
            return CurrentBalance + theAmount;
        }

        #endregion

        #region Enum values

        public static IEnumerable<Necessity> NecessityValues => Enum.GetValues(typeof(Necessity)).Cast<Necessity>();

        public static IEnumerable<RegularityInterval> RegularityIntervalValues => Enum.GetValues(typeof(RegularityInterval)).Cast<RegularityInterval>();

        #endregion

        #region ImportBankActivities

        RelayCommand m_ImportTransactions;

        public ICommand ImportTransactions
        {
            get
            {
                if (m_ImportTransactions == null)
                {
                    m_ImportTransactions = new RelayCommand(m => setTransactions());
                }
                return m_ImportTransactions;
            }
        }

        private void setTransactions()
        {
            var fileName = getTransactionFilePath();
            if (fileName == string.Empty)
            {
                return;
            }
            Transactions = ListToSortedObservableCollection(Model.ImportTransactions(fileName));
            OnPropertyChanged(nameof(Transactions));
        }

        private ObservableCollection<Transaction> ListToSortedObservableCollection(List<Transaction> theList)
        {
            var orderedObservableCollection = new ObservableCollection<Transaction>();
            theList.Sort((x, y) => y.Info.TransactionDate.CompareTo(x.Info.TransactionDate));
            foreach (var item in theList)
            {
                orderedObservableCollection.Add(item);
            }
            return orderedObservableCollection;
        }

        private string getTransactionFilePath()
        {
            var openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }
            return string.Empty;
        }


        #endregion
    }
}
