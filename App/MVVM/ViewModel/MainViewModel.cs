using App.MVVM.Model;
using App.MVVM.ViewItem;
using App.MVVM.ViewModel;
using App.Registries;
using FinanceOverviewApp.Core;
using System;

namespace FinanceOverviewApp.MVVM.ViewModel
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
            BankBalanceVM = ViewItemFactory.ViewItems[BankBalanceViewItem.Id].ViewModel as BankBalanceViewModel?? throw new NullReferenceException();
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
