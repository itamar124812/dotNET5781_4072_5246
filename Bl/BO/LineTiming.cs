using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BO
{
    public class LineTiming
    {
        public int Id { get; set; }
        public int LineNumber { get; set; }
        public TimeSpan ExitTime { get; set; }
        public string LastStation { get; set; }
        public TimeSpan ArrivalTime { get; set; }
    }
}
