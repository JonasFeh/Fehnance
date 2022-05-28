using Data.InputData;

namespace Data
{
    /// <summary>
    /// Thread safe singleton implementation
    /// </summary>
    public sealed class ProcessImage
    {
        #region Singleton

        private ProcessImage() { }
        static ProcessImage() { }

        private static readonly ProcessImage _instance = new ProcessImage();

        public static ProcessImage Instance => _instance;
        
        #endregion

        public List<BankActivity> BankActivities { get; set; } = new List<BankActivity>();

    }
}
