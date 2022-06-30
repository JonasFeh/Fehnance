using Data.InputData;
using Data.ProcessedData;

namespace Data.BankAtivity
{
    public class BankActivityFactory
    {
        private BankActivityType ResolveBankActivityType(BankActivityInfo info)
        {
            return info.TransactionVolume.Value >= 0 ? BankActivityType.Income : BankActivityType.Spendings;
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
                        Type = ResolveBankActivityType(info)
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
