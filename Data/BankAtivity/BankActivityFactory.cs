using Data.InputData;
using Data.ProcessedData;
using System.Text;

namespace Data.BankAtivity
{
    public class BankActivityFactory
    {
        private BankActivityType ResolveBankActivityType(BankActivityInfo info)
        {
            return info.TransactionVolume.Value >= 0 ? BankActivityType.Income : BankActivityType.Spendings;
        }

        private String NormalizeName(string name)
        {
            name.Trim();
            char currentChar = char.MinValue;
            var normalizedName = new StringBuilder();
            foreach (var character in name)
            {
                if (char.IsWhiteSpace(character))
                {
                    if (!char.IsWhiteSpace(currentChar))
                    {
                        normalizedName.Append(character);
                        currentChar = character;
                    }
                }
                else
                {
                    normalizedName.Append(character);
                    currentChar = character;
                }
            }
            var result = normalizedName.ToString().Normalize();
            return result;
        }

        public BankActivity Create(IDictionary<BankActivityInfo, BankActivity> bankActivities, BankActivityInfo info)
        {
            if (bankActivities == null) throw new ArgumentNullException("Bank activities needed to construct bank acitivities!");

            if (info == null) throw new ArgumentNullException("Cannot construct a Bankactivity with no information!");

            if (!bankActivities.ContainsKey(info))
            {
                return new BankActivity
                {
                    Info = info,
                    Data = new BankActivityData
                    {
                        Amount = info.TransactionVolume,
                        Category = new ProcessedData.Category
                        {
                            MainCategory = String.Empty,
                            SubCategory = String.Empty
                        },
                        Date = info.TransactionDate,
                        Regularity = new ProcessedData.Regularity(),
                        Type = ResolveBankActivityType(info),
                        Name = NormalizeName(info.Creditor),
                    }
                };
            }

            return new BankActivity
            {
                Info = info,
                Data = bankActivities[info].Data,
            };
        }
    }
}
