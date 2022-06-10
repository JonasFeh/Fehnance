using Common;
using Data;
using Data.InputData;
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
            var Data = DataSerializer.Load<List<BankActivity>>(Constants.Data.FileNameBankActivities, out var data);

            ProcessImage.BankActivities = data;
        }

        #endregion
    }
}
