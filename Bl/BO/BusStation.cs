using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BO
{
    public class BusStation
    {
      public IEnumerable<StationLine> LinesPassingThrough;
      public  int StationNumber { get; set; }

    }
}
