using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Bl.BO;
namespace Bl
{
    class Bo
    {
        static void Main(string[] args)
        {
            BlImp bl = Bl.BlImp.Instance;
            bl.flag = true;
            bl.rate = 20;
            bl.StartSimulator(TimeSpan.Parse("5:00:00"),20,t=>t=(TimeSpan)t.Add(TimeSpan.FromSeconds(20)));
            TravelOperator travelOperator = TravelOperator.Instance;
            Console.ReadKey();
        }
    }
}
