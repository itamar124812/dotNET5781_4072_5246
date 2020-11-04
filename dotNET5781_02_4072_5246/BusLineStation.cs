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
        private TimeSpan time_from_last_s;
        public TimeSpan Time_from_last_s {set { time_from_last_s = value;  } get { return time_from_last_s; } }
        double distance (BusStop A,BusStop B)
        {
           return Math.Sqrt(Math.Pow(A.latritude - B.latritude,2) + Math.Pow(A.longitude - B.longitude,2));
        }
        public BusLineStation(int bus,TimeSpan A,double B):base(bus)
        {
            time_from_last_s = A;
            distance_from_last_s = B;
        }
        public BusLineStation(int bus, double a, double b,TimeSpan  A, double B):base(bus,a,b)
        {
            time_from_last_s = A;
            distance_from_last_s = B;
        }
        public BusLineStation():base()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int hour = r.Next(0, 2);
            int minute = r.Next(0, 60);
            int second = r.Next(0, 60);
            time_from_last_s = new TimeSpan(hour, minute, second);
            double temp= r.NextDouble();
            temp *= Math.Pow(1.1, minute) + hour * 270;
        }
    }
}
