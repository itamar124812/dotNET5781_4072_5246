using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace dotNET5781_02_4072_5246
{
   enum area { General,North,South,Center,Jerusalem}
    class LineBus
    {
        List<BusLineStation> The_line_bus = new List<BusLineStation>();
       private  BusLineStation final_stop;
        public BusLineStation Final_stop { set{ if (value == The_line_bus.Last()) final_stop = value; else final_stop = The_line_bus.Last(); } get { return final_stop; } }
        private BusLineStation start_station;
        public int bus_line_key;
        private area Area;
        public int  AREA { set{ if (value < 0 || value > 4) throw new ArgumentException("There are only five areas. The first starts at 0 and the last ends at 4"); else Area = (area)value; } get { return (int)Area; } }
        public override string ToString()
        {
            string result = string.Format("Bus line key:{0} ,The area: {1} ,Station numbers:", bus_line_key,Area);
            foreach(BusLineStation A in The_line_bus)
            {
                result += A.BusStopkey + " ";
            }
            return result;
        }
        public void enter_a_new_stop()
        {

        }
    }
}
