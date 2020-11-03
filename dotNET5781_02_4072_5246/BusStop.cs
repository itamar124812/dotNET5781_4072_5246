using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET5781_02_4072_5246
{
    class BusStop
    {
        private int BusStationKey;

        public int BusStopkey { set { if (value >= 1000000 || value < 0) throw new ArgumentException("The Input was invalid"); else BusStationKey = value; } get { return BusStationKey; } }
        private double Latitude;
        private double Longitude;
        public double latritude { set { if (Math.Abs(value) > 90) throw new ArgumentException("The Input was invalid"); } get { return Latitude; } }
        public double longitude { set { if (Math.Abs(value) > 180) throw new ArgumentException("The Input was invalid"); } get { return Longitude; } }
        public void set_latritude()
        {
            Random r = new Random();
            double temp = r.NextDouble();
            latritude= (temp * 2.1 + 31);
        }
        public void set_longitude()
        {
            Random r = new Random();
            double temp = r.NextDouble();
            longitude = (temp * 1.2 + 34.3);
        }
        public override string ToString()
        {
            string result = string.Format("Bus Station Code:{0} , {1}N, {2}E", BusStationKey,latritude,longitude);
            return result;
        }
        protected BusStop(int bus)
        {
            BusStopkey = bus;
            set_latritude();
            set_longitude();
        }
        protected BusStop(int bus,double a,double b)
        {
            BusStopkey = bus;
            latritude = a;
            longitude = b;
        }
    }
}
