using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace dotNET5781_3B_4072_5246
{
    enum Bus_status { ready_for_travel, on_the_road, refueling, in_treatment }
    class Upgraded_Bus : dotNET5781_01_4072_5426.bus
    {
        public int status { get { return (int)Status; } set { if (value > 4 || value < 1) throw new ArgumentException("There are only four statuses."); else { Status = (Bus_status)(value-1); } } }
        private Bus_status Status;
        public Upgraded_Bus ():base()
        {
            status = 1;
        }
        public Upgraded_Bus(string lisence_bus, int REfull, int Mailage, int f_lt, DateTime StartDate, int STatus) : base(lisence_bus, REfull, Mailage, f_lt, StartDate)
        {
            status = STatus;
        }
        public void Make_a_trip(int distance)
        {
            if (!check_General_treatment(distance) && Status != (Bus_status)3)
            {
                if (Refull(distance) && Status != (Bus_status)2)
                {
                    if (Status == (Bus_status)1)
                    {
                        throw new InvalidOperationException("It is not possible to travel. The bus in the middle of one like that");
                    }
                    else
                    {
                        Status = (Bus_status)1;
                        new Thread(() => {
                             make_a_trip(distance); Random rnd = new Random(DateTime.Now.Millisecond);
                            int average_speed = rnd.Next(20, 50);
                            int time = (distance / average_speed) * 6000;
                            Thread.Sleep(time);  Status = (Bus_status)0; }).Start();
                    }
                }
                else throw new InvalidOperationException("There is not enough fuel to make the trip.");
            }
            else throw new InvalidOperationException("It is not possible to travel the bus needs to undergo treatment"); 
        }
        public void Make_a_refull()
        {
            status = 3;
            new Thread(() => { make_a_refull(); Thread.Sleep(12000); status = 1; });
        }
        public void Make_a_treatment()
        {
            status = 4;
            new Thread(() => { make_a_treatment(); Thread.Sleep(144000); status = 1; });
        }
    }
    
}
