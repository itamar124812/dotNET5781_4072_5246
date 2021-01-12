using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BO
{
    public class StationLine
    {
        public int IDLine { get; set; }
        public int LineNumber { get; set; }
        public String LastStop;
        public TimeSpan Arrivaltimes { get; set; }



    }
}
