using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    class Bus
    {
        private int License_plate;
        private int Mileage;
        private int Fueltank;
        TimeSpan Licensing_date { get; set; }
        public int L_P
        {
            get
            {
                return License_plate;
            }
            set 
            {
                License_plate = value;
            }
        }
        public int Miles//get acsess to the variable Mileage
        {
            get
            {
                return Mileage;
            }
            set
            {
                Mileage = value;
            }
        }
        public int F_l//get acsess to the variable Fueltank
        {
            get
            {
                return Fueltank;
            }
            set
            {
                Fueltank = value;
            }
        }

        //להוסיף סטטוס
    }
}
