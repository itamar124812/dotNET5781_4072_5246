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
            return string.Format("The line ID: {0} Number: {1} at area: {2} passing throuth: ",Id, Code, (DalApi.DO.Areas)Area) + stations;

            
        }
    }
}       
