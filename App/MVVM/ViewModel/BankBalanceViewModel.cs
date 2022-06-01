using App.MVVM.Model;
using Data.InputData;
using FinanceOverviewApp.Core;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FinanceOverviewApp.MVVM.ViewModel
{
    public class BankBalanceViewModel : ViewModelBase<BankBalanceModel>
    {
        public List<BankActivity> BankActivities => Model.BankActivities;

        #region ImportBankActivities

        RelayCommand m_ImportBankActivities;

        public ICommand ImportBankActivities
        {
            get
            {
                if (m_ImportBankActivities == null)
                {
                    m_ImportBankActivities = new RelayCommand(m => Model.ImportBankActivities(getBankActivityFilePath()));
                }
                return m_ImportBankActivities;
            }
        }


        private string getBankActivityFilePath()
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
