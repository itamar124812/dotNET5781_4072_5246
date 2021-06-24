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
    public class TravelOperator : IObservable<LineTiming>
    {
        public void startDrive()
        {
            foreach (var item in BlImp.Instance.GetsAllLines())
            {
                LineTiming lineTiming = new LineTiming(item.Id,BlImp.Instance.GetStartLineTrip(item.Id).StartTime, item.PassingThrough.First().Code, item.Code, BlImp.Instance.GetStartLineTrip(item.Id).ExitTime, item.PassingThrough.Last().Code, BlImp.Instance.GetStartLineTrip(item.Id).ArrivalTime);
            }
        }
        //        public IBl Bl = BlFactory.GetBl();
        //        public IDal Dl = DalFactory.GetDL();
        //        public List<LineTiming> lineTimings = new List<LineTiming>();
        //        #region Singelton
        //        private static TravelOperator instance
        //        {
        //            get;set;
        //        }
        //        public static TravelOperator Instance
        //        {
        //            get
        //            {
        //                if (instance == null) instance = new TravelOperator();
        //                return instance;
        //            }
        //        }
        //        private TravelOperator()
        //        {
        //            new Thread(() =>
        //           {
        //               foreach (var item in Dl.GetAllLineTrips())
        //               {
        //                  while( ((BlImp.Instance.sclock).TotalHours%24)>=5 && BlImp.Instance.flag)
        //                   {
        //                       startTravel(item.LindId, Dl.GetLine(item.LindId).Code, BlImp.Instance.sclock, Dl.GetStation(Dl.GetLine(item.LindId).LastStation).Name, TimeBetweenStation(item.LindId, BlImp.Instance.Station));
        //                       Thread.Sleep((int)(TimeBetweenStation(item.LindId).TotalSeconds/ BlImp.Instance.rate));
        //                   }
        //               }
        //           }).Start();
        //    }
        //        #endregion

        //        private void startTravel(int id, int lineNumber, TimeSpan exitTime, string lastStation, TimeSpan arrivalTime)
        //        {
        //            bool flag = true;

        //                new Thread(() =>
        //                {
        //                    int i = 1;
        //                    Random rnd = new Random();
        //                    TimeSpan time = TimeBetweenStation(id);
        //                    LineTiming lineTiming = new LineTiming() { Id = id, ExitTime = exitTime, LastStation = lastStation, ArrivalTime = arrivalTime, LineNumber = lineNumber };
        //                    lineTimings.Add(lineTiming);
        //                    while (BlImp.Instance.sclock - exitTime >= TimeBetweenStation(id, Bl.GetLine(id).PassingThrough.ElementAt(i).Code) && BlImp.Instance.flag &&flag) 
        //                    {
        //                        time -= TimeBetweenStation(id, Bl.GetLine(id).PassingThrough.ElementAt(i).Code);
        //                        if (Bl.GetLine(id).PassingThrough.ElementAt(i).Code == BlImp.Instance.Station)
        //                        {

        //                        }
        //                        ++i;
        //                        double mul = rnd.NextDouble();
        //                        mul = mul * 2.1 - 0.1;
        //                        if (Bl.GetLine(id).PassingThrough.Count() >= i)
        //                        {
        //                            flag = false;
        //                        }
        //                        Thread.Sleep((int)Math.Abs(TimeBetweenStation(id, Bl.GetLine(id).PassingThrough.ElementAt(i).Code).TotalSeconds * mul));
        //                    }

        //                }).Start();


        //        }
        //        private TimeSpan TimeBetweenStation(int id,int stationNum)
        //        {
        //            LineStation ls = new LineStation();
        //            TimeSpan time = new TimeSpan();
        //            foreach (var item in Bl.GetLine(id).PassingThrough)
        //            {
        //                if (item.Code == stationNum) return time;
        //                try
        //                {

        //                    DalApi.DO.AdjacentStations AS = Dl.GetAdjacentStations(Dl.GetStation(item.Code), Dl.GetStation(ls.Code));
        //                    time += AS.Time;
        //                }
        //                catch (Exception)
        //                {
        //                }
        //                ls = item;
        //            }
        //            return time;
        //        }
        //        private TimeSpan TimeBetweenStation(int id)
        //        {
        //            LineStation ls = new LineStation();
        //            TimeSpan time = new TimeSpan();
        //            foreach (var item in Bl.GetLine(id).PassingThrough)
        //            {
        //                try
        //                {
        //                    DalApi.DO.AdjacentStations AS = Dl.GetAdjacentStations(Dl.GetStation(item.Code), Dl.GetStation(ls.Code));
        //                    time += AS.Time;
        //                }
        //                catch (Exception)
        //                {
        //                }
        //                ls = item;
        //            }
        //            return time;
        //        }
        public IDisposable Subscribe(IObserver<LineTiming> observer)
        {
            
        }
    }
}
