using App.MVVM.Model;
using Data.BankAtivity;
using FinanceOverviewApp.Core;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FinanceOverviewApp.MVVM.ViewModel
{
    public class BankBalanceViewModel : ViewModelBase<BankBalanceModel>
    {
        public override void OnStartup()
        {
            _bankActivities = new ObservableCollection<BankActivity>();
        }

        private ObservableCollection<BankActivity> _bankActivities;
        public ObservableCollection<BankActivity> BankActivities
        {
            get
            {
                if( _bankActivities == null)
                {
                    _bankActivities = new ObservableCollection<BankActivity>(Model.BankActivities);
                }
                return _bankActivities;
            }
            set => SetProperty(ref _bankActivities, value);
        }

        private BankActivity _selectedBankActivity;

        public BankActivity SelectedBankActivity
        {
            get => _selectedBankActivity;
            set => SetProperty(ref _selectedBankActivity, value);
        }

        #region ImportBankActivities

        RelayCommand m_ImportBankActivities;

        public ICommand ImportBankActivities
        {
            get
            {
                if (m_ImportBankActivities == null)
                {
                    m_ImportBankActivities = new RelayCommand(m => BankActivities = new ObservableCollection<BankActivity>(Model.ImportBankActivities(getBankActivityFilePath())));
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
