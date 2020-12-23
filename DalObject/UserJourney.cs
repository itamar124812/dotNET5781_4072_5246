using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalObject
{
    class UserJourney
    {
        private int Line_ID;
        private int IDStationStation;
        String username;

        public int L_I //same name;
        {
            get
            {
                return Line_ID;
            }
            set
            {
                Line_ID = value;
            }
        }

        public int IDS 
        {
            get
            {
                return IDStationStation;
            }
            set
            {
                IDStationStation = value;
            }
        }


        public void SETusername(String r)
        {
            username = r;
        }
        public String GETusername()
        {
            return username;
        }
    }
}
