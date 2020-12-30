using System;
using System.Collections.Generic;
using System.Text;

namespace DalApi.DO
{
    public class AdjacentStations
    { 
        public  int Station1 { get; set; }
        public    int Station2 { get; set; }
        public double distance { get; set; }
        public TimeSpan Time { get; set; }
    }
}
