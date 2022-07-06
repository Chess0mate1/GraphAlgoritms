using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Windows.Input;
using GraphAlgoritms.Core.Types;

namespace GraphAlgoritms.Core.Converters
{
    public class KeyToAlgoritmExecuteTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((KeyEventArgs)value).Key switch
            {
                Key.Right => AlgoritmExecuteType.NextStep,
                Key.Left => AlgoritmExecuteType.PreviousStep,
                Key.Up => AlgoritmExecuteType.End,
                Key.Down => AlgoritmExecuteType.Start,
                _ => AlgoritmExecuteType.None
            };
            //return value switch
            //{
            //    AlgoritmExecuteType.NextStep => Key.Right,
            //    AlgoritmExecuteType.PreviousStep => Key.Right,
            //    AlgoritmExecuteType.End => Key.Right,
            //    AlgoritmExecuteType.Start => Key.Right,
            //    _ => Key.Right
            //};
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
