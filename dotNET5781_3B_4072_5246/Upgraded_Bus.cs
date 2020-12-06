using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;

namespace dotNET5781_3B_4072_5246 
{
    
    enum Bus_status { ready_for_travel, on_the_road, refueling, in_treatment }
 
   public  class Upgraded_Bus : dotNET5781_01_4072_5426.bus , INotifyPropertyChanged     
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int status { get { return (int)Status; } set{ if (value > 4 || value < 1) throw new ArgumentException("There are only four statuses."); else {  Status = (Bus_status)(value-1);if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Status")); } } }
        private Bus_status Status;
        private int timewait;
        public int Timewait { set { if (value >= 0) timewait = value;if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("timewait")); } get { return timewait; } }
        public Upgraded_Bus ():base()
        {
            status = 1;
            Timewait = 0;
        }
        public Upgraded_Bus(string lisence_bus, int REfull, int Mailage, int f_lt, DateTime StartDate,DateTime flt) : base(lisence_bus, REfull, Mailage, f_lt, StartDate,flt)
        {
            status = 1;
            Timewait = 0;
        }
        public void Make_a_trip(int distance)
        {
            if (!check_General_treatment(distance) && Status != Bus_status.in_treatment)
            {
                if (Refull(distance) && Status != Bus_status.refueling)
                {
                    if (Status == Bus_status.on_the_road)
                    {
                        throw new InvalidOperationException("It is not possible to travel. The bus in the middle of one like that");
                    }
                    else
                    {
                        status = 2;
                        new Thread(() =>
                        {
                            // Console.WriteLine("start_thread");
                            make_a_trip(distance); Random rnd = new Random(DateTime.Now.Millisecond);
                            int average_speed = rnd.Next(20, 50);
                            int time = (distance / average_speed) * 6000 + (distance % average_speed) * 100;
                            Timewait = time;
                            Thread.Sleep(time); status=1;

                        }).Start();
                        TimeWAITchange();
                    }
                }
                else if (!Refull(distance)) throw new InvalidOperationException("There is not enough fuel to make the trip.");
                else throw new InvalidOperationException("The bus is in general treatment at the moment so it is not possible to travel");
            }
            else if (check_General_treatment(distance)) throw new InvalidOperationException("It is not possible to travel the bus needs to undergo treatment");
            else throw new InvalidOperationException("The bus is currently refueling so it is not possible to travel");
        }
        public void Make_a_refull()
        {
            status = 3;
            new Thread(() => { make_a_refull(); Timewait = 12000; Thread.Sleep(12000); status = 1; }).Start();
            TimeWAITchange();

        }
        public void Make_a_treatment()
        {
               status = 4;
                new Thread(() => { make_a_treatment(); Timewait = 144000; Thread.Sleep(144000); status = 1; }).Start();
                TimeWAITchange();     
        }
        private void TimeWAITchange()
        {
                new Thread(() => 
                {
                    while (Timewait > 100)
                    {
                        Timewait -= 100;
                        Thread.Sleep(100);
                    }
                    Timewait = 0;
                }).Start();
        }
        public override string ToString()
        {
            
            return base.ToString(); 
        }
    }
    
}
