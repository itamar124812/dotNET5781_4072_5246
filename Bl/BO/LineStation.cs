using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BO
{
    public class LineStation
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public double DistanceFromLastStation { get; set; }
        public TimeSpan TimeFromLastStation { get; set; }
        public override string ToString()
        {
            return Code.ToString();
        }
    }
}
