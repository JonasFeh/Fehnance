using Common;
using Data;
using Data.InputData;
using Data.ProcessedData;
using Data.Serializer;
using System.Collections.Generic;

namespace App.Startup
{
    internal static class StartupManager
    {
        private static DataSerializer DataSerializer { get; set; }
        private static ProcessImage ProcessImage => ProcessImage.Instance;

        static StartupManager()
        {
            DataSerializer = new DataSerializer();
        }

        #region Loading Data

        public static void LoadData()
        {
            LoadBankActivitiesInternal();
        }

        private static void LoadBankActivitiesInternal()
        {
            DataSerializer.Load<KeyValuePair<BankActivityInfo, ProcessedBankActivity>>(Constants.Data.FileNameBankActivities, out var data);

            ProcessImage.BankActivities = data;
        }

        #endregion
    }
}
