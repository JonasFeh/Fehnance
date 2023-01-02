using App.Core;
using App.Shutdown;
using System.Windows;

namespace App.MVVM.TopBar
{
    internal class TopBarModel : ModelBase
    {

        internal void InitiateShutDown()
        {
            ShutdownManager.ExecuteShutdownRoutine();
        }

        internal void MinimizeWindow()
        {
            var mainWindow = Application.Current.MainWindow;
            mainWindow.WindowState = WindowState.Minimized;
        }

        internal void Maximize()
        {
            var mainWindow = Application.Current.MainWindow;

            if (mainWindow.WindowState == WindowState.Maximized)
            {
                mainWindow.WindowState = WindowState.Normal;
            }
            else if (mainWindow.WindowState == WindowState.Normal)
            {
                mainWindow.WindowState = WindowState.Maximized;
            }
        }
    }
}
