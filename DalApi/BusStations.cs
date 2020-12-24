using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalObject
{
    class Bus_stations
    {
        private int StationCode;

        String stationName;
        //Location     צריך להגדיר מיקום
        //adress       צריך להגדיר כתובת



        public void SETstationName(String r)
        {
            stationName = r;
        }
        public String GETstationName()
        {
            return stationName;
        }
        public int S_C
        {
            get
            {
                return StationCode;
            }
            set
            {
                StationCode = value;
            }

        }

    }
}
