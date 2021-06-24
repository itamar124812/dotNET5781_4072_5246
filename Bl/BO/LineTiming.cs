using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BO
{
    public class LineTiming
    {
        public LineTiming()
        {
        }
        public LineTiming(int id, TimeSpan startTime, int currentStation, int lineNumber, TimeSpan exitTime, int lastStation, TimeSpan arrivalTime)
        {
            Id = id;
            StartTime = startTime;
            this.currentStation = currentStation;
            LineNumber = lineNumber;
            ExitTime = exitTime;
            LastStation = lastStation;
            ArrivalTime = arrivalTime;
        }

        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public int currentStation { get; set; }
        public int LineNumber { get; set; }
        public TimeSpan ExitTime { get; set; }
        public int LastStation { get; set; }
        public TimeSpan ArrivalTime { get; set; }
    }
}
