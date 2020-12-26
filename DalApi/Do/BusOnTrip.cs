using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi.DO
{
    class BusOnTrip
    {
        private static int counter = 0;
        int RunningNum => ++counter;
        int LicenseNum { set; get; }
        int Lineld { set; get; }
        TimeSpan PlannedTakeOff { set; get; }
        TimeSpan ActualTakeOff { set; get; }
        int PrevStation { set; get; }
        TimeSpan PrevStationA1 { set; get; }
        TimeSpan NextstatinA1 { set; get; }
    }
}
