using Data.BankAtivity.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace App
{
    public class NecessityToDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Necessity necessity)
            {
                return necessity.GetDescription();
            }
            return "Unknown";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value is String description))
            {
                switch (description)
                {
                    case "Unknown":
                        return Necessity.Neutral;
                    default:
                        return Necessity.Neutral;
                }
            }
            return Necessity.Neutral;
        }
    }
}
