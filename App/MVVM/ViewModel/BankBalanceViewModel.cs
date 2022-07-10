using App.MVVM.Model;
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

        private ObservableCollection<Transaction> _transactions;
        public ObservableCollection<Transaction> Transactions
        {
            get
            {
                if( _transactions == null)
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
            set => SetProperty(ref _selectedTransaction, value);
        }

        #region Enum values

        public static IEnumerable<Necessity> NecessityValues => Enum.GetValues(typeof(Necessity)).Cast<Necessity>();

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
