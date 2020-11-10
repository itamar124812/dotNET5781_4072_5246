using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;//כדי לממש את הממשק IEnumerable
using System.Runtime.Remoting.Services;
using System.Runtime.InteropServices;

namespace dotNET5781_02_4072_5246
{
    
    class CollectionBusLines : IEnumerable
    {
        
        List<LineBus> collectin_of_lines = new List<LineBus>();//יצירת אוסף של קווי האוטובוסים
        public List<int> keys_for_stations=new List<int>();
        
        public void add()
        {
            station_key();
            LineBus A = new LineBus();
            collectin_of_lines.Add(A);
        }

        private void station_key()
        {
            int counter = 0;
            foreach (LineBus B in collectin_of_lines)
            {
                for (int i = 0; i < B.The_line_bus.Count; i++)
                {
                    keys_for_stations.Insert (counter ,B.The_line_bus[i].BusStopkey);
                    counter++;
                }
            }
        }

        public void add(LineBus A)
        {
            station_key();
            collectin_of_lines.Add(A);
        }
        public void remove(LineBus a)
        {
            collectin_of_lines.Remove(a);
        }
        public void remove(int bus_code)
        {
            if(check_line(bus_code))
            {
                foreach(LineBus A in collectin_of_lines)
                {
                    collectin_of_lines.Remove(A);
                }
            }
        }
         public List <LineBus> passing_through(int bus_code)
        {
            bool flag = false;
            List<LineBus> result = new List<LineBus>();
            BusLineStation B = new BusLineStation(bus_code);
            foreach(LineBus A in collectin_of_lines)
            {
                
                if(A.cheke_station(B))
                {
                    result.Add(A);
                    flag = true;
                }
                
            }
            if(flag == false)
            {
                throw new ArgumentException("There are no lines passing through the station");
            }
            return result; 
        }
        public bool check_line(int temp)
        {
            foreach(LineBus A in collectin_of_lines)
            {
                if (temp == A.bus_line_key)
                    return true;
            }
            return false;
        }

        public LineBus find(int temp)
        {    
                foreach(LineBus A in collectin_of_lines)
                {
                   if (A.bus_line_key == temp)
                    return A;
                }
            throw new ArgumentOutOfRangeException("There is no such line in the system");
        }
       
        public List<LineBus> Finding_an_optimal_route(BusLineStation Current, BusLineStation destination)
        {
            List<LineBus> result = new List<LineBus>();
            foreach(LineBus a in collectin_of_lines)
            {
                result=passing_through(destination.BusStopkey);
            }
            result.Sort();
            return result;
        }
        public IEnumerator GetEnumerator()
        {
            return collectin_of_lines.GetEnumerator();
        }
    } 
}
