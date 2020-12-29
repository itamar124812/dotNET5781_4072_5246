using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi.DO
{
   public class BusOnTrip
    {
        private static int counter = 0;
       public  int RunningNum => ++counter;
        public int LicenseNum { set; get; }
       public int Lineld { set; get; }
   public      TimeSpan PlannedTakeOff { set; get; }
    public     TimeSpan ActualTakeOff { set; get; }
    public    int PrevStation { set; get; }
     public TimeSpan PrevStationA1 { set; get; }
    public TimeSpan NextstatinA1 { set; get; }
    }
}
