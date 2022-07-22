using App.MVVM.Model;
using Common.Currency;
using Data.BankAtivity;
using Data.BankAtivity.Enums;
using FinanceOverviewApp.Core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FinanceOverviewApp.MVVM.ViewModel
{
    public class BankBalanceViewModel : ViewModelBase<BankBalanceModel>
    {
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
                if (_transactions == null)
                {
                    _transactions = new ObservableCollection<Transaction>(Model.Transactions);
                }
                return _transactions;
            }
            set => SetProperty(ref _transactions, value);
        }

        private Transaction _selectedTransaction;

        public Transaction SelectedTransaction
        {
            get => _selectedTransaction;
            set
            {
                SetProperty(ref _selectedTransaction, value);
            }
        }

        #endregion

        #region Enum values

        public static IEnumerable<Necessity> NecessityValues => Enum.GetValues(typeof(Necessity)).Cast<Necessity>();

        public static IEnumerable<RegularityInterval> RegularityIntervalValues => Enum.GetValues(typeof(RegularityInterval)).Cast<RegularityInterval>();

        public static IEnumerable<RegularityType> RegularityTypeValues => Enum.GetValues(typeof(RegularityType)).Cast<RegularityType>();

        #endregion

        #region ImportBankActivities

        RelayCommand m_ImportTransactions;

        public ICommand ImportTransactions
        {
            get
            {
                if (m_ImportTransactions == null)
                {
                    m_ImportTransactions = new RelayCommand(m => Transactions = new ObservableCollection<Transaction>(Model.ImportTransactions(getTransactionFilePath())));
                }
                return m_ImportTransactions;
            }
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
