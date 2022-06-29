using Data.InputData;
using Data.ProcessedData;

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

        public IDictionary<BankActivityInfo, ProcessedBankActivity> BankActivities { get; set; } = new Dictionary<BankActivityInfo, ProcessedBankActivity>();

    }
}
