using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WPF_Resc
{
    [ValueConversion(typeof(bool), typeof(SolidColorBrush))]
    class MyColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var bools = values.Cast<bool>().ToArray();
            var brush = new SolidColorBrush(
                Color.FromRgb(
                    (byte)(bools[0] ? 255 : 0),
                    (byte)(bools[1] ? 255 : 0),
                    (byte)(bools[2] ? 255 : 0)
                    )
                );
            return brush;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
