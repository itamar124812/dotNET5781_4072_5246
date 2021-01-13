using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BO
{
   public class LineBus
    {
        public int Id { set; get; }
        public int Code { get; set; }
        public int Area { get; set; }
        public IEnumerable<LineStation> PassingThrough;
        public override string ToString()
        {
            string stations = string.Empty;
            foreach (var item in PassingThrough)
            {
                stations += item.ToString() + " ";
            }
            return string.Format("The line: {0} at area: {1} passing throuth: ", Code, (DalApi.DO.Areas)Area) + stations;

            
        }
    }
}       
