using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.Windows.Media;
using System.Windows.Data;

namespace dotNET5781_3B_4072_5246
{
    class ConvertTime : IValueConverter
    {
        public object Convert(object convertint, Type targetType, object parameter, CultureInfo culture)
        {
            int a = (int)convertint;
            if (a > 0)
            {      
                  int Days = a / 144000;
                  int Hours = (a - (Days * 144000)) / 6000;
                  int Minutes = (a - ((Days * 144000) + Hours * 6000)) / 100;
                  if (Days >= 1)
                  {
                      string A = string.Format("{0} Days, {1} Hours, {2} Minutes", Days, Hours, Minutes);
                      return A;
                  }
                  else if(Hours>=1)
                  {
                    string A = string.Format("{0} Hours, {1} Minutes", Hours, Minutes);
                    return A;
                  }
                  else
                  {
                    string A = string.Format("{0} Minutes", Minutes);
                    return A;
                  }
            }
            else return '0';
        }
        public object ConvertBack(object a, Type e, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
