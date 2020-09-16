using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Notepad
{
    [ValueConversion(typeof(bool), typeof(string))]
    class WrapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null && value.GetType() != typeof(bool)) return DependencyProperty.UnsetValue;
            if ((bool)value) return "Wrap";
            return "NoWrap";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
