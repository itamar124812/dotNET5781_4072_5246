using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlGui.PO
{
    class PL_viewST : IComparable<PL_viewST>
    {
        public int Id { get; set; }
        public int LineId { get; set; }
        public TimeSpan StartAt { get; set; }
        public TimeSpan NextStationTime { get; set; }
        public int CountStation { get; set; }
        public int StartStation { get; set; }
        public int EndStation { get; set; }

        public int NowStation { get; set; }
        public int FirstStation { get; set; }
        public int NextStation { get; set; }
        public int count { get; set; }
        public int fre { get; set; }
        public int LastStation { get; set; }
        public bool Pass = false;

        public int CompareTo(PL_viewST other)
        {
            return StartAt.CompareTo(other.StartAt);
        }
    }
}
