using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    class LineExit
    {
        private int Bus_Line_ID;
        private int Frequency;//תדירות
        public int BLD
        {
            get
            {
                return Bus_Line_ID;
            }
            set
            {
                Bus_Line_ID = value;
            }
        }
        public int frequency
        {
            get
            {
                return Frequency;
            }
            set
            {
                Frequency = value;
            }
        }
        TimeSpan Start_Time { get; set; }
        TimeSpan Finish_time//רק אם התדירות היא לא אפס
        {
            get; set;
        }







        }
}
