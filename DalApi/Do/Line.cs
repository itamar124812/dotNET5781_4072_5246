using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi.DO
{
   public enum Areas { North, South, Central, Jerusalem, General };
    public class Line
    {
        public static int RunningNum = 0;
        public int Id { get; set; }
        public int Code { get; set; }
        public Areas Area { get; set; }
        public int FirstStation { get; set; }
        public int LastStation { get; set; }
    }
}
