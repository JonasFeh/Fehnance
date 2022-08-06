using App.Registries;
using Common;
using Common.Currency;
using Data;
using Data.BankAtivity;
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

        public static void StartUp()
        {
            LoadBankActivitiesInternal();
            LoadBalanceInternal();
            ViewItemFactory.StartUpMVVM();
        }

        private static void LoadBankActivitiesInternal()
        {
            DataSerializer.Load<List<Transaction>>(Constants.Data.FileNameBankActivities, out var data);

            if(data == null)
            {
                return;
            }

            var dictionary = new Dictionary<TransactionInfo, Transaction>();
            foreach (var bankActivity in data)
            {
                dictionary.Add(bankActivity.Info, bankActivity);
            }

            ProcessImage.BankActivities = dictionary;
        }

        private static void LoadBalanceInternal()
        {
            DataSerializer.Load<Balance>(Constants.Data.FileNameBalance, out var data);
            if (data == null)
            {
                ProcessImage.BankBalance = new Balance 
                { 
                    Amount = new Euro(),
                    TimeStamp = System.DateTime.Now
                };
                return;
            }

            ProcessImage.BankBalance = data;
        }

        #endregion
    }
}
