using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi.DO
{
   public class Trip
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Lineld {get; set; }
        public int InStaiton { get; set; }
        public TimeSpan InAt { get; set; }
        public int OutStation { get; set; }
        public TimeSpan OutAt { get; set; }
    }
}
