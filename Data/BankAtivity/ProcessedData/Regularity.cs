using Data.BankAtivity.Enums;

namespace Data.BankAtivity.ProcessedData
{
    public struct Regularity
    {
        public RegularityType Type { get; set; }

        public RegularityInterval? Interval { get; set; }

        public Regularity(RegularityType type, RegularityInterval interval) : this(type)
        {
            Interval = interval;
        }

        public Regularity(RegularityType type)
        {
            Type = type;
            if (Type == RegularityType.Irregular)
            {
                Interval = null;
            }
            else
            {
                Interval = RegularityInterval.Unknown;
            }
        }

        public Regularity()
        {
            Type = RegularityType.Unknown;
            Interval = RegularityInterval.Unknown;
        }
    }
}
