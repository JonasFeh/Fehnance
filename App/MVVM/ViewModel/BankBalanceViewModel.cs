using App.MVVM.Model;
using Data.InputData;
using FinanceOverviewApp.Core;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FinanceOverviewApp.MVVM.ViewModel
{
    public class BankBalanceViewModel : ViewModelBase<BankBalanceModel>
    {
        private ObservableCollection<RawBankActivity> _bankActivities;
        public ObservableCollection<RawBankActivity> BankActivities
        {
            get
            {
                if (_bankActivities == null)
                {
                    _bankActivities = new ObservableCollection<RawBankActivity>();
                }

                return _bankActivities;
            }
            set
            {
                SetProperty(ref _bankActivities, value);
            }
        }

        #region ImportBankActivities

        RelayCommand m_ImportBankActivities;

        public ICommand ImportBankActivities
        {
            get
            {
                if (m_ImportBankActivities == null)
                {
                    m_ImportBankActivities = new RelayCommand(m => BankActivities = new ObservableCollection<RawBankActivity>(Model.ImportBankActivities(getBankActivityFilePath())));
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
