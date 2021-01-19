using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.BO;
namespace Bl
{
    class Bo
    {
        static void Main(string[] args)
        {
            BlImp bl = Bl.BlImp.Instance;
            bl.ADDStation(12, 12, 19, "bana");
            bl.AddLine(20, 0, 19);
            bl.GetAllLinesForStation(19);
           IEnumerable<Bl.BO.LineBus> lines= bl.GetBusFromArea(0);
            foreach (var item in lines)
            {
                Console.WriteLine(item);

            }
            Console.ReadKey();
        }
    }
}
