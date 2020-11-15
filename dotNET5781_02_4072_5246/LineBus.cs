using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace dotNET5781_02_4072_5246
{
   enum area { General,North,South,Center,Jerusalem}
    class LineBus:IComparable
    {
        //List of line stations and other required parameters
        public List<BusLineStation> The_line_bus = new List<BusLineStation>();
       private  BusLineStation final_stop;
        public BusLineStation Final_stop { set{ if (value == The_line_bus.Last()) final_stop = value; else final_stop = The_line_bus.Last(); } get { return final_stop; } }
        private BusLineStation start_station;
        public int bus_line_key;
        private area Area;
        public int  AREA { set{ if (value < 0 || value > 4) throw new ArgumentException("There are only five areas. The first starts at 0 and the last ends at 4"); else Area = (area)value; } get { return (int)Area; } }
        //to string requested
        public override string ToString()
        {
            string result = string.Format("Bus line key:{0} ,The area: {1} ,Station numbers:", bus_line_key,Area);
            foreach(BusLineStation A in The_line_bus)
            {
                result += A.BusStopkey + " ";
            }
            return result;
        }
        //A function that checks if a particular station exists on the line
        public bool cheke_station(BusLineStation A)
        {
            foreach (BusLineStation a in The_line_bus)
            {
                if (a.BusStopkey == A.BusStopkey) return true;
            }
            return false;
        }
        //A function that checks if a particular station exists on the line and returns its index
        public int Search_Starion(BusLineStation A)
        {
            if (cheke_station(A))
            {
                int temp = 0;
                for (int i = 0; i < The_line_bus.Count(); i++)
                {
                    if (The_line_bus[i].BusStopkey == A.BusStopkey)
                        temp = i;
                }
                return temp;
            }
            else return -1;
        }
        //A function that receives a station and a station number and inserts a new station immediately after the requested station
        public void enter_a_new_stop(BusLineStation A,int  bus_code)
        { 
                TimeSpan time;
                double distance;
                Console.WriteLine("Enter the travel time from the last stop");
                string input  = Console.ReadLine();
                TimeSpan.TryParse(input, out time);
                Console.WriteLine("Enter the distance from the last stop");
                input = Console.ReadLine();
                double.TryParse(input, out distance);
                BusLineStation b = new BusLineStation(bus_code, time, distance);
                int index = Search_Starion(A);
            if (index > 0)
            {
                The_line_bus.Insert(index, b);
                if (final_stop == A)
                    final_stop = The_line_bus.Last();
            }
            else
            {
                index = The_line_bus.Count-1;
                The_line_bus.Insert(index, b);
                if (final_stop == A)
                    final_stop = The_line_bus.Last();
            }
        }
        //A function that receives a station number and pushes it to the top of the list
        public void enter_head(int temp)
        {
            TimeSpan time;
            double distance;
            Console.WriteLine("Enter the travel time from the last stop");
            string input = Console.ReadLine();
            TimeSpan.TryParse(input, out time);
            Console.WriteLine("Enter the distance from the last stop");
            input = Console.ReadLine();
            double.TryParse(input, out distance);
            BusLineStation b = new BusLineStation(temp, time, distance);
            The_line_bus.Insert(0,b);
            start_station = The_line_bus.First();
        }
        //Unnecessary function that should return the distance between the stations
        public double distance_between_station(BusLineStation A,BusLineStation B)
        {
            if (cheke_station(A) && cheke_station(B))
            {
                double result = 0;
                int index1 = Search_Starion(A);
                int index2 = Search_Starion(B);
                if (index1<index2)
                {
                    for (int i = index1;i<index2;i++)
                    {
                        result += The_line_bus[i].Distance_from_last_s;
                    }
                }
                else if(index1 == index2)
                {
                    return 0;
                }
                else
                {
                    for (int i = index2; i < index1; i--)
                    {
                        result += The_line_bus[i].Distance_from_last_s;
                    }
                }
                return result;
            }
            else throw new ArgumentException("The stations didn't found");
        }
        //A function that returns the time between two stations
        public TimeSpan time_from_station(BusLineStation A, BusLineStation B)
        {
            if (cheke_station(A) && cheke_station(B))
            {
                TimeSpan result=new TimeSpan(0);
                int index1 = Search_Starion(A);
                int index2 = Search_Starion(B);
                if (index1 < index2)
                {
                    for (int i = index1+1; i < index2; i++)
                    {
                        result += The_line_bus[i].Time_from_last_s;
                    }
                }
                else if (index1 == index2)
                {
                    return result;
                }
                else
                {
                    for (int i = index2-1; i < index1; i--)
                    {
                        result += The_line_bus[i].Time_from_last_s;
                    }
                }
                return result;
            }
            else throw new ArgumentException("The stations didn't found");
        }
        //A function that returns a route between stations and turns out to be unnecessary
        public LineBus Sub_route(BusLineStation A, BusLineStation B)
        {
            LineBus return_Bus = new LineBus();
            if (cheke_station(A) && cheke_station(B))
            {
                int index1 = Search_Starion(A);
                int index2 = Search_Starion(B);
                if (index1 < index2)
                {
                    for (int i = index1; i < index2; i++)
                    {
                        return_Bus.The_line_bus[i - index1] = The_line_bus[i];
                    }
                }
                else if (index1 == index2)
                    throw new ArgumentException("Not funny! The two stations are identical");
                else throw new ArgumentException("Sorry, the bus is not traveling in this direction");
            }
            else throw new ArgumentException("The stations didn't found");
            return return_Bus;
        }
       public int CompareTo(object obj)
        {
            int temp;
            if (obj == null) return 0;
            LineBus otherLine = obj as LineBus;
            Console.WriteLine("What is the number of the station where you are?");
            string input = Console.ReadLine();
            int.TryParse(input, out temp);
            BusLineStation A=new BusLineStation(temp);
            Console.WriteLine("What number your destination station?");
            input = Console.ReadLine();
            int.TryParse(input, out temp);
            BusLineStation b = new BusLineStation(temp);
            if (otherLine != null && cheke_station(A) && cheke_station(b))
            {
                return this.time_from_station(A,b).CompareTo(otherLine.time_from_station(A,b));
                    
            }
            else throw new ArgumentException("The comparison cannot exist");
        }
     
        public LineBus (int A)
        {
            bus_line_key = A;
            Random rnd = new Random(DateTime.Now.Millisecond);
            AREA= rnd.Next(0, 4);
        }
        public LineBus (int A,int AREa)
        {
            bus_line_key = A;
            AREA = AREa;
        }

       public LineBus()
        { 
            Console.WriteLine("What is the bus line number you would like to add?");
            string input = Console.ReadLine();
            int temp;
            int.TryParse(input, out temp);
            bus_line_key = temp;
            Console.WriteLine("pleae select area:0 for  general,1 for North,2 for South, 3 for Center,4 for Jerusalem");
            input = Console.ReadLine();
            int.TryParse(input, out temp);
            AREA = temp;
            
        }
        //Pushes a certain station to the top of the line
        public void enter_head(BusLineStation A)
        {
            The_line_bus.Insert(0, A);
            start_station = A;
        }
        //remove station by her number
        public void remove_station(int station_code)
        {
            if (cheke_minimum_stations())
            {
                BusLineStation A = new BusLineStation(station_code);
                int index = Search_Starion(A);
                if (index >= 0)
                {
                    The_line_bus.Remove(The_line_bus[index]);
                }
                else throw new ArgumentOutOfRangeException("There is no such station in the line.");
            }
            else throw new InvalidOperationException("There must be at least 2 stations");
        }
        //Prevents deleting a station from a line that has less than two stations
        private bool cheke_minimum_stations()
        {
            if (The_line_bus.Count >= 2)
                return true;
            return false;
        }

    }
}
