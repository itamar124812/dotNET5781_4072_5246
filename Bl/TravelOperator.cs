using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Bl.BO;
using BlApi;

namespace Bl
{
    public class TravelOperator
    {
        public IBl Bl = BlFactory.GetBl();
        #region Singelton
        private static TravelOperator instance
        {
            get;set;
        }
        public static TravelOperator Instance
        {
            get
            {
                if (instance == null) instance = new TravelOperator();
                return instance;
            }
        }
        private TravelOperator()
        {
             
    }
        #endregion
        private void startTravel(int id, int lineNumber, TimeSpan exitTime, string lastStation, DateTime arrivalTime)
        {
            new Thread(() => {
                LineTiming lineTiming = new LineTiming() { Id = id,ExitTime=exitTime,LastStation=lastStation,ArrivalTime=arrivalTime, LineNumber=lineNumber };                
                foreach (var item in Bl.GetLine(id).PassingThrough)
                {
                    
                }
            }).Start();
        }
    }
}
