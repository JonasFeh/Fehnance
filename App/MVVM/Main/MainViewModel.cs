using App.MVVM.BankBalance;
using App.MVVM.Home;
using App.MVVM.Stock;
using App.MVVM.TopBar;
using App.Registries;
using FinanceOverviewApp.Core;
using System;

namespace App.MVVM.Main
{
    class MainViewModel : ViewModelBase<MainModel>
    {
        public RelayCommand HomeViewCommand { get; set; }

        public RelayCommand BankBalanceViewCommand { get; set; }

        public RelayCommand StockViewCommand { get; set; }

        public TopBarViewModel TopBarVM { get; set; }

        public HomeViewModel HomeVM { get; set; }

        public BankBalanceViewModel BankBalanceVM { get; set; }

        public StockViewModel StockVM { get; set; }


        private ViewModelBase m_CurrenView;

        public ViewModelBase CurrentView
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
            BankBalanceVM = ViewItemFactory.ViewItems[BankBalanceViewItem.Id].ViewModel as BankBalanceViewModel ?? throw new NullReferenceException();
            TopBarVM = new TopBarViewModel();
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
