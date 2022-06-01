using App.MVVM.Model;
using FinanceOverviewApp.Core;

namespace FinanceOverviewApp.MVVM.ViewModel
{
    class MainViewModel : ViewModelBase<MainModel>
    {
        public RelayCommand HomeViewCommand { get; set; }

        public RelayCommand BankBalanceViewCommand { get; set; }

        public RelayCommand StockViewCommand { get; set; }


        public HomeViewModel HomeVM { get; set; }

        public BankBalanceViewModel BankBalanceVM { get; set; }

        public StockViewModel StockVM { get; set; }


        private object m_CurrenView;

        public object CurrentView
        {
            get { return m_CurrenView; }
            set
            {
                m_CurrenView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            StockVM = new StockViewModel();
            BankBalanceVM = new BankBalanceViewModel();
            CurrentView = HomeVM;
            HomeViewCommand = new RelayCommand(m =>
            {
                CurrentView = HomeVM;
            });

            BankBalanceViewCommand = new RelayCommand(m =>
           {
               CurrentView = BankBalanceVM;
           });

            StockViewCommand = new RelayCommand(m =>
            {
                CurrentView = StockVM;
            });
        }
    }
}
