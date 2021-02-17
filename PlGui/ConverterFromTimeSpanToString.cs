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
            int Munits = (int)time.TotalMinutes % 60;
            int hours = (int)time.TotalHours % 24;
            return string.Format("{0,2:#00}:{1,2:#00}:{2,2:#00}",hours, Munits, seconds);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
