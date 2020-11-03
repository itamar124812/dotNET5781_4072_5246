using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace dotNET5781_02_4072_5246
{
    class BusLineStation:BusStop
    {
        private double distance_from_last_s;
        public double Distance_from_last_s { set{ distance_from_last_s = value;  } get { return distance_from_last_s; } }
        private DateTime time_from_last_s;
        public DateTime Time_from_last_s {set { time_from_last_s = value;  } get { return time_from_last_s; } }
        double distance (BusStop A,BusStop B)
        {
           return Math.Sqrt(Math.Pow(A.latritude - B.latritude,2) + Math.Pow(A.longitude - B.longitude,2));
        }
        public BusLineStation(int bus,DateTime A,double B):base(bus)
        {
            time_from_last_s = A;
            distance_from_last_s = B;
        }
        public BusLineStation(int bus, double a, double b,DateTime A, double B):base(bus,a,b)
        {
            time_from_last_s = A;
            distance_from_last_s = B;
        }

    }
}
