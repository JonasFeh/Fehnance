﻿using App.Registries;
using Common;
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
            ViewItemFactory.StartUpMVVM();
        }

        private static void LoadBankActivitiesInternal()
        {
            DataSerializer.Load<List<Transaction>>(Constants.Data.FileNameBankActivities, out var data);

            if(data == null)
            {
                return;
            }

            var dictionary = new Dictionary<BankActivityInfo, Transaction>();
            foreach (var bankActivity in data)
            {
                dictionary.Add(bankActivity.Info, bankActivity);
            }

            ProcessImage.BankActivities = dictionary;
        }

        #endregion
    }
}
