using App.Startup;
using System.Windows;

namespace FinanceOverviewApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            StartupManager.LoadData();
            StartupManager.SaveData();

        }

        protected override void OnExit(ExitEventArgs e)
        {
            StartupManager.SaveData();
            base.OnExit(e);
        }
    }
}
