using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi.DO
{
   public class LineStation
    {
        int Id { get; set; }
        String UserName { get; set; }
        int Linled { get; set; }
        int InStation { get; set; }
        TimeSpan InAt { get; set; }
        int OutStation { get; set; }
        TimeSpan OutAt { get; set; }
    }
}
