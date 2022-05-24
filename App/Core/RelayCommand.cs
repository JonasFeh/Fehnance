using System;
using System.Windows.Input;

namespace FinanceOverviewApp.Core
{
    class RelayCommand : ICommand
    {
        private Action<object> m_execute;
        private Func<object, bool> m_CanExecute;

        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> theExecute, Func<object, bool> theCanExecute = null)
        {
            m_execute = theExecute;
            m_CanExecute = theCanExecute;
        }

        public bool CanExecute(object theParameter)
        {
            return m_CanExecute == null || m_CanExecute(theParameter);
        }

        public void Execute(object theParameter)
        {
            m_execute(theParameter);
        }
    }
}
