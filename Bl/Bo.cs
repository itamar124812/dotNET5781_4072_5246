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
            BlImp bl = new BlImp();
            bl.ADDStation(12, 12, 19, "bana");
            bl.AddLine(20, 0, 19);
        }
    }
}
