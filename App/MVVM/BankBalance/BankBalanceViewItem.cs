using App.Core;
using FinanceOverviewApp.MVVM.View;
using System;
using System.Windows.Controls;

namespace App.MVVM.BankBalance
{
    public class BankBalanceViewItem : ViewItem<BankBalanceViewModel, BankBalanceModel>
    {
        public static Guid Id => new Guid("7A83D0DC-E02C-4396-BAB3-9A6A5F06EEC5");


        private readonly BankBalanceViewModel _bankBalanceViewModel = new BankBalanceViewModel();
        public override BankBalanceViewModel ViewModel => _bankBalanceViewModel;

        private readonly BankBalanceModel _bankBalanceModel = new BankBalanceModel();
        public override BankBalanceModel Model => _bankBalanceModel;

        private readonly UserControl _userControl = new BankBalanceView();
        public override UserControl View => _userControl;

    }
}
