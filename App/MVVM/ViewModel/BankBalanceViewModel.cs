using App.MVVM.Model;
using Data.InputData;
using Data.ProcessedData;
using FinanceOverviewApp.Core;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FinanceOverviewApp.MVVM.ViewModel
{
    public class BankBalanceViewModel : ViewModelBase<BankBalanceModel>
    {

        private ObservableCollection<KeyValuePair<BankActivityInfo, ProcessedBankActivity>> _bankActivities = new ObservableCollection<KeyValuePair<BankActivityInfo, ProcessedBankActivity>>();
        public ObservableCollection<KeyValuePair<BankActivityInfo, ProcessedBankActivity>> BankActivities
        {
            get => _bankActivities;
            set => SetProperty(ref _bankActivities, value);
        }

        #region ImportBankActivities

        RelayCommand m_ImportBankActivities;

        public ICommand ImportBankActivities
        {
            get
            {
                if (m_ImportBankActivities == null)
                {
                    m_ImportBankActivities = new RelayCommand(m => BankActivities = new ObservableCollection<KeyValuePair<BankActivityInfo, ProcessedBankActivity>>(Model.ImportBankActivities(getBankActivityFilePath())));
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
