using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BO
{
   public class LineBus
    {
        public int Code { get; set; }
        public IEnumerable<LineStation> PassingThrough;
    }
}
