using App.Core;
using Data;
using Data.InputData;
using Data.Parser;
using System.Collections.Generic;

namespace App.MVVM.Model
{
    public class BankBalanceModel : ModelBase
    {
        public List<BankActivity> BankActivities { get; set; }

        public void ImportBankActivities(string FilePath)
        {
            if (FilePath == null || FilePath == string.Empty) return;

            var bankActivities = ProcessImage.Instance.BankActivities;
            bankActivities.AddRange( CsvParser.ParseBankActivities(FilePath) );
            BankActivities = bankActivities;
        }
    }
}
