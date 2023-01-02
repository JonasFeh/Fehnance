using FinanceOverviewApp.Core;

namespace App.MVVM.TopBar
{

    internal class TopBarViewModel : ViewModelBase<TopBarModel>
    {
        public RelayCommand MinimizeWindow { get; set; }
        public RelayCommand MaximizeWindow { get; set; }
        public RelayCommand CloseApplication { get; set; }

        public TopBarViewModel()
        {
            MinimizeWindow = new RelayCommand(m =>
            {
                Model.MinimizeWindow();
            });
            MaximizeWindow = new RelayCommand(m =>
            {
                Model.Maximize();
            });
            CloseApplication = new RelayCommand(m =>
            {
                Model.InitiateShutDown();
            });
        }

    }
}
