using Data.BankAtivity;
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

        public IDictionary<BankActivityInfo, Transaction> BankActivities { get; set; } = new Dictionary<BankActivityInfo, Transaction>();

        public Balance BankBalance { get; set; } = new Balance();

    }
}
