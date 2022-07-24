using App.Core;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FinanceOverviewApp.Core
{
    public class ViewModelBase<TModel> : ViewModelBase, INotifyPropertyChanged where TModel : ModelBase, new()
    {
        public ViewModelBase()
        {
            Model.PropertyChanged += OnModelPropertyChanged;
        }
        protected TModel Model { get; set; } = new TModel();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }

        public virtual void OnStartup()
        {
            
        }

        public virtual void OnShutdown()
        {

        }
    }

    public class ViewModelBase
    {
        
    }
}
