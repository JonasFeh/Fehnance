using Data.BankAtivity.ProcessedData;
using Data.InputData;

namespace Data.BankAtivity
{
    public class BankActivityFactory
    {
        public BankActivity Create(IDictionary<BankActivityInfo, BankActivity> bankActivities, BankActivityInfo info)
        {
            if (bankActivities == null) throw new ArgumentNullException("Bank activities needed to construct bank acitivities!");

            if (info == null) throw new ArgumentNullException("Cannot construct a Bankactivity with no information!");

            if (!bankActivities.ContainsKey(info))
            {
                return new BankActivity
                {
                    Info = info,
                    Data = new BankActivityNullData()
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
