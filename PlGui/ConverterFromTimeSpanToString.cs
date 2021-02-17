using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PlGui
{
    public class ConverterFromTimeSpanToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan time = (TimeSpan)value;
            int seconds =(int) time.TotalSeconds % 60;
            int Munits = (int)time.TotalSeconds % 3600;
            int hours = (int)time.TotalSeconds % (3600 * 60);
            return string.Format("{0}:{1}:{2}", seconds, Munits, hours);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
