using App.Core;
using Data;
using Data.InputData;
using Data.Parser;
using System.Collections.Generic;

namespace App.MVVM.Model
{
    public class BankBalanceModel : ModelBase
    {

        public List<RawBankActivity> ImportBankActivities(string FilePath)
        {
            if (FilePath == null || FilePath == string.Empty) return new List<RawBankActivity>();

            var bankActivities = ProcessImage.Instance.BankActivities;
            bankActivities.AddRange( CsvParser.ParseBankActivities(FilePath) );
            return bankActivities;
        }
    }
}
