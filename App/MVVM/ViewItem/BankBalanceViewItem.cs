using App.Core;
using App.MVVM.Model;
using FinanceOverviewApp.MVVM.View;
using FinanceOverviewApp.MVVM.ViewModel;
using System;
using System.Windows.Controls;

namespace App.MVVM.ViewItem
{
    public class BankBalanceViewItem : ViewItem<BankBalanceViewModel, BankBalanceModel>
    {
        public static Guid Id => new Guid("7A83D0DC-E02C-4396-BAB3-9A6A5F06EEC5");

        public override BankBalanceViewModel ViewModel => new BankBalanceViewModel();

        public override BankBalanceModel Model => new BankBalanceModel();

        public override UserControl View => new BankBalanceView();
    }
}
