using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Bl.BO;
using BlApi;
using DalApi;

namespace Bl
{
    public class TravelOperator
    {
        public IBl Bl = BlFactory.GetBl();
        public IDal Dl = DalFactory.GetDL();
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
            new Thread(() =>
           {
               foreach (var item in Dl.GetAllLineTrips())
               {
                  while( ((BlImp.Instance.sclock).TotalHours%24)>=5 && BlImp.Instance.flag)
                   {
                       startTravel(item.LindId, Dl.GetLine(item.LindId).Code, BlImp.Instance.sclock, Dl.GetStation(Dl.GetLine(item.LindId).LastStation).Name, TimeBetweenStation(item.LindId, BlImp.Instance.Station));
                       Thread.Sleep((int)(TimeBetweenStation(item.LindId).TotalSeconds/ BlImp.Instance.rate));
                   }
               }
           }).Start();
    }
        #endregion
        private void startTravel(int id, int lineNumber, TimeSpan exitTime, string lastStation, TimeSpan arrivalTime)
        {
            new Thread(() =>
            {
                LineTiming lineTiming = new LineTiming() { Id = id, ExitTime = exitTime, LastStation = lastStation, ArrivalTime = arrivalTime, LineNumber = lineNumber };
                TimeBetweenStation(id);

            }).Start();
        }
        private TimeSpan TimeBetweenStation(int id,int stationNum)
        {
            LineStation ls = new LineStation();
            TimeSpan time = new TimeSpan();
            foreach (var item in Bl.GetLine(id).PassingThrough)
            {
                if (item.Code == stationNum) return time;
                try
                {

                    DalApi.DO.AdjacentStations AS = Dl.GetAdjacentStations(Dl.GetStation(item.Code), Dl.GetStation(ls.Code));
                    time += AS.Time;
                }
                catch (Exception)
                {
                }
                ls = item;
            }
            return time;
        }
        private TimeSpan TimeBetweenStation(int id)
        {
            LineStation ls = new LineStation();
            TimeSpan time = new TimeSpan();
            foreach (var item in Bl.GetLine(id).PassingThrough)
            {
                try
                {
                    DalApi.DO.AdjacentStations AS = Dl.GetAdjacentStations(Dl.GetStation(item.Code), Dl.GetStation(ls.Code));
                    time += AS.Time;
                }
                catch (Exception)
                {
                }
                ls = item;
            }
            return time;
        }
    }
}
