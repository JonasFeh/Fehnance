using Common.Currency;
using Data.InputData;
using Microsoft.VisualBasic.FileIO;

namespace Data.Parser
{
    public static class CsvParser
    {
        public static IEnumerable<BankActivityInfo> ParseBankActivities(string filePath)
        {
            var bankActivities = new List<BankActivityInfo>();
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");

                // Discard head;
                parser.ReadFields();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields() ?? new string[] { };

                    if (fields.Length == 0)
                    {
                        continue;
                    }

                    DateTime dateTime;
                    BankActivityInfo currentBankActivity;
                    if (DateTime.TryParseExact(fields[1], "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateTime))
                    {
                        currentBankActivity = new BankActivityInfo
                        {
                            BankAccountIban = fields[0],
                            TransactionDate = dateTime,
                            TransactionVolume = new Euro(decimal.Parse(fields[14])),
                            TransactionType = fields[3],
                            Description = fields[4],
                            Creditor = fields[11],
                            CreditorIban = fields[12],
                            CreditorSwift = fields[13]
                        };
                    }
                    else if (DateTime.TryParseExact(fields[1], "dd.MM.yy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateTime))
                    {
                        currentBankActivity = new BankActivityInfo
                        {
                            BankAccountIban = fields[0],
                            TransactionDate = dateTime,
                            TransactionVolume = new Euro(decimal.Parse(fields[14])),
                            TransactionType = fields[3],
                            Description = fields[4],
                            Creditor = fields[11],
                            CreditorIban = fields[12],
                            CreditorSwift = fields[13]
                        };
                    }
                    else
                    {
                        currentBankActivity = new BankActivityInfo
                        {
                            BankAccountIban = fields[0],
                            TransactionDate = DateTime.Today,
                            TransactionVolume = new Euro(decimal.Parse(fields[14])),
                            TransactionType = fields[3],
                            Description = fields[4],
                            Creditor = fields[11],
                            CreditorIban = fields[12],
                            CreditorSwift = fields[13]
                        };
                    }

                    

                    bankActivities.Add(currentBankActivity);
                }
            }
            return bankActivities;
        }
    }
}