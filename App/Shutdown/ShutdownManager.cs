using Common;
using Data;
using Data.BankAtivity;
using Data.InputData;
using Data.Serializer;
using System.Collections.Generic;
using System.Linq;

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
            DataSerializer.Save<List<Transaction>>(ProcessImage.Instance.BankActivities.Values.ToList(), Constants.Data.FileNameBankActivities);
        }

        public static void ExecuteShutdownRoutine()
        {
            SaveBankActivities();
            Shutdown();
        }

    }
}
