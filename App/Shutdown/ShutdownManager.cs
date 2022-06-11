using Common;
using Data;
using Data.InputData;
using Data.Serializer;
using System.Collections.Generic;

namespace App.Shutdown
{
    internal static class ShutdownManager
    {
        private static DataSerializer DataSerializer { get; set; }

        static ShutdownManager()
        {
            DataSerializer = new DataSerializer();
        }

        private static void Shutdown()
        {
            System.Windows.Application.Current.Shutdown();
        }

        private static void SaveBankActivities()
        {
            DataSerializer.Save<List<RawBankActivity>>(ProcessImage.Instance.BankActivities, Constants.Data.FileNameBankActivities);
        }

        public static void ExecuteShutdownRoutine()
        {
            SaveBankActivities();
            Shutdown();
        }

    }
}
