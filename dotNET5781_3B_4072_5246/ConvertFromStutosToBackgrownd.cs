using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;



namespace dotNET5781_3B_4072_5246
{
    
    class ConvertFromStutosToBackgrownd : IValueConverter 
    {
       
       public object Convert(object convertint,Type targetType,    object parameter,  CultureInfo culture)
        {
            int a = (int)convertint;
            if (a == 0)
                return Brushes.White;
            else if (a == 1)
                return Brushes.Yellow;
            else if (a == 2)
                return Brushes.LimeGreen;
            else return Brushes.Gray;
        }
        public object ConvertBack(object a,Type e, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
