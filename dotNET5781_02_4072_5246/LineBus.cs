using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET5781_02_4072_5246
{
   enum area { General,North,South,Center,Jerusalem}
    class LineBus
    {
        List<BusLineStation> The_line_bus = new List<BusLineStation>();
       private  BusLineStation final_stop;
        public BusLineStation Final_stop { set{ if (value == The_line_bus.Last()) final_stop = value; }get { return final_stop; } }
        private BusLineStation start_station;
        private int bus_line_key;
        private int Area;
    }
}
