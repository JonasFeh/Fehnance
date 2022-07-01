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

            StartupManager.StartUp();

        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
