using System;
using System.Collections.Generic;
using System.Text;

namespace DalApi.DO
{
    public class AdjacentStations
    { 
        public  int Station1 { get; set; }
        public    int Station2 { get; set; }
        public double Distance { get { if (this.Distance.Equals(null)) return 100; else return this.Distance; } set { this.Distance = value; } }
        public TimeSpan Time { get { return this.Time; } set { if (value == null) TimeSpan.TryParse("1:00", out value); else this.Time = value; } }
    }
}
