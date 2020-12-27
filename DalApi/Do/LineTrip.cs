using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi.DO
{
   public class LineTrip
    {
        int Id { get; set; }
        TimeSpan StartAt { get; set; }
        int Lindld { get; set; }
        TimeSpan Frequency { get; set; }
        TimeSpan FinishAt { get; set; }
    }
}
