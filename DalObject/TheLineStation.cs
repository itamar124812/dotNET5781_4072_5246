using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalObject
{
    class TheLineStation
    {
        private int LineID;
        private int StationCode;
        private int StatioNumberOnLine;
        public int L_I 
        {
            get
            {
                return LineID;
            }
            set
            {
                LineID = value;
            }
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
        public int S_N
        {
            get
            {
                return StatioNumberOnLine;
            }
            set
            {
                StatioNumberOnLine = value;
            }
        }
    }
}
