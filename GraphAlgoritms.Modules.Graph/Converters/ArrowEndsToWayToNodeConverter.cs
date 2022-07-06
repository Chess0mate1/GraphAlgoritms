using GraphAlgoritms.Core.CustomUIElements;
using GraphAlgoritms.Modules.Graph.ViewModels;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace GraphAlgoritms.Modules.Graph.Converters
{
    public class ArrowEndsToWayToNodeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return ((WayToNode)value) switch
            {
                WayToNode.None => ArrowEnds.None,
                WayToNode.First => ArrowEnds.Start,
                WayToNode.Second => ArrowEnds.End,
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((ArrowEnds)value) switch
            {
                ArrowEnds.None => WayToNode.None,
                ArrowEnds.Start => WayToNode.First,
                ArrowEnds.End => WayToNode.Second,
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
        }
    }
}
