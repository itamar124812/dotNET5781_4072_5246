using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;//כדי לממש את הממשק IEnumerable
using System.Runtime.Remoting.Services;
using System.Runtime.InteropServices;
using System.CodeDom;

namespace dotNET5781_02_4072_5246
{
    
    class CollectionBusLines :  IEnumerable 
    {
        
         public  List<LineBus> collectin_of_lines = new List<LineBus>();//יצירת אוסף של קווי האוטובוסים
         public bool[] existind_stations = new bool[1000000];
         public BusLineStation return_station(int bus_code)
        {
            foreach(LineBus A in collectin_of_lines)
            {
                for (int i = 0; i < A.The_line_bus.Count; i++)
                {
                    if (A.The_line_bus[i].BusStopkey == bus_code)
                        return A.The_line_bus[i];
                }
            }
            throw new ArgumentException("the station did'nt exists.");
        }
        
        public void add()
        {
            LineBus A = new LineBus();
            collectin_of_lines.Add(A);
         
        }

        

        public void add(LineBus A)
        {
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
                LineBus B=new LineBus(0);
                foreach(LineBus A in collectin_of_lines)
                {
                     B = A;
                }
                collectin_of_lines.Remove(B);
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
