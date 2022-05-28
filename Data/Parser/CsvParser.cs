﻿using Common.Currency;
using Data.InputData;
using Microsoft.VisualBasic.FileIO;

namespace Data.Parser
{
    public static class CsvParser
    {
        public static IEnumerable<BankActivity> ParseBankActivities(string filePath)
        {
            var bankActivities = new List<BankActivity>();
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    
                    string[] fields = parser.ReadFields() ?? new string[] { };

                    if(fields.Length == 0)
                    {
                        continue;
                    }

                    var currentBankActivity = new BankActivity
                    {
                        BankAccountIban = fields[0],
                        TransactionDate = DateTime.ParseExact(fields[1], "dd-mm-yyyy", System.Globalization.CultureInfo.InvariantCulture),
                        TransactionVolume = new Euro(double.Parse(fields[14])),
                        TransactionType = fields[3],
                        Description = fields[4],
                        Creditor = fields[11],
                        CreditorIban = fields[12],
                        CreditorSwift = fields[13]
                    };

                    bankActivities.Add(currentBankActivity);
                }
            }
            return bankActivities;
        }
    }
}