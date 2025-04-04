using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace Independiente.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = (bool)value;

            // Si el parámetro es "true", invierte el valor
            if (parameter != null && bool.TryParse(parameter.ToString(), out bool invert) && invert)
            {
                boolValue = !boolValue;
            }

            // Devuelve Visibility.Visible si el valor es verdadero, de lo contrario Visibility.Collapsed
            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Visibility)value == Visibility.Visible;
        }
    }


}
