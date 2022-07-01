using FinanceOverviewApp.Core;
using System;
using System.Windows.Controls;

namespace App.Core
{
    public abstract class ViewItem<TViewModel, TModel> : ViewItem
        where TViewModel : ViewModelBase<TModel> 
        where TModel : ModelBase, new() 
    {
        public static Guid Id { get; }

        public abstract TViewModel ViewModel { get; }

        public abstract TModel Model { get; }

        public abstract UserControl View { get; }

        public override void OnStartup()
        {
            Model.OnStartup();
            ViewModel.OnStartup();
        }
    }

    public abstract class ViewItem
    {
        public abstract void OnStartup();
    }
}
