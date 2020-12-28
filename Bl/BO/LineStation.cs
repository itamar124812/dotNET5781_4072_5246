using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BO
{
    class LineStation
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public double DistanceFromLastStation { get; set; }
        public TimeSpan TimeFromLastStation { get; set; }
    }
}
