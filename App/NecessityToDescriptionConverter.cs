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
                return description switch
                {
                    "Unknown" => Necessity.Neutral,
                    "Very unnecessary" => Necessity.VeryUnnecessary,
                    "Unnecessary" => Necessity.Unnecessary,
                    "Rather unnecessary" => Necessity.RatherUnnecessary,
                    "Neutral" => Necessity.Neutral,
                    "Rather necessary" => Necessity.RatherNecessary,
                    "Necessary" => Necessity.Necessary,
                    "Very necessary" => Necessity.VeryNecessary,
                    _ => (object)Necessity.Neutral,
                };
            }
            return Necessity.Neutral;
        }
    }
}
