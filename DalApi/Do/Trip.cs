using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi.DO
{
   public class Trip
    {
        int Id { get; set; }
        string UserName { get; set; }
        int Lineld {get; set; }
        int InStaiton { get; set; }
        TimeSpan InAt { get; set; }
        int OutStation { get; set; }
        TimeSpan OutAt { get; set; }
    }
}
