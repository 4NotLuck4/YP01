using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace PractWork3.Converters
{
    public class CelsiusToFahrenheitConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is double celsius)
                return celsius * 9 / 5 + 32;
            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is double fahrenheit)
                return (fahrenheit - 32) * 5 / 9;
            return null;
        }
    }
}