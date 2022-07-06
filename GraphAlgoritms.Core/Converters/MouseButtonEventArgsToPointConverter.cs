using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

namespace GraphAlgoritms.Core.Converters
{
    public class MouseButtonEventArgsToPointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var args = (MouseEventArgs)value;
            var element = (FrameworkElement)parameter;
            var point = args.GetPosition(element);
            return point;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
