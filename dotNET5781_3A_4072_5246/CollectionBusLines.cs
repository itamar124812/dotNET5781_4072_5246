using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;// IEnumerable
using System.Runtime.Remoting.Services;
using System.Runtime.InteropServices;
using System.CodeDom;

namespace dotNET5781_02_4072_5246
{
    
    class CollectionBusLines :  IEnumerable 
    {
        //Create a collection of bus lines
        public List<LineBus> collectin_of_lines = new List<LineBus>();
        //A Boolean array with 1,000,000 keys that each key indicates the existence of a station.
        public bool[] existind_stations = new bool[1000000];
        //A function that receives a station by the station number and returns an instance of the station
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
   
       // Add a line to a collection without parameters
        public void add()
        {
            LineBus A = new LineBus();
            foreach (LineBus B in collectin_of_lines)
            {
                if (B.bus_line_key == A.bus_line_key)
                    throw new ArgumentException("This line is already exits.");
            }
            collectin_of_lines.Add(A);
         
        }


        //Add a line to a collection with parameters
        public void add(LineBus A)
        {
            foreach (LineBus B in collectin_of_lines)
            {
                if (B.bus_line_key == A.bus_line_key)
                    throw new ArgumentException("This line is already exits.");
            }
            collectin_of_lines.Add(A);
            
        }

        //Remove a line using a line number
        public void remove(int bus_code)
        {
            bool flag = false;
            if(check_line(bus_code))
            {
                LineBus B=new LineBus(0);
                foreach(LineBus A in collectin_of_lines)
                {
                    if (A.bus_line_key == bus_code)
                    {
                        B = A; 
                    }
                }
                collectin_of_lines.Remove(B);
                for (int i = 0; i < B.The_line_bus.Count;i++ )
                {
                    flag = false;
                    foreach (LineBus A in collectin_of_lines)
                    {
                        if(A.cheke_station(B.The_line_bus[i]))
                        {
                            flag = true;
                        }
                    }
                    if (flag == false)
                    { 
                        existind_stations[B.The_line_bus[i].BusStopkey] = false;
                    }
                }
            }
        }
        //A function that returns the list of lines passing through a station
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
        //A Boolean function checks with a specific line existing in the system
        public bool check_line(int temp)
        {
            foreach(LineBus A in collectin_of_lines)
            {
                if (temp == A.bus_line_key)
                    return true;
            }
            return false;
        }
        // function checks with a particular line present in the system and returns it
        public LineBus find(int temp)
        {    
                foreach(LineBus A in collectin_of_lines)
                {
                   if (A.bus_line_key == temp)
                    return A;
                }
            throw new ArgumentOutOfRangeException("There is no such line in the system");
        }
        // A function that receives two stations and returns the sorted list of lines passing through them 
        public List<LineBus> Finding_an_optimal_route(BusLineStation Current, BusLineStation destination)
        {
            List<LineBus> result = new List<LineBus>();
            result=passing_through(destination.BusStopkey);
            for (int i=0;i<result.Count;i++)
            {
                if(!(result[i].cheke_station(Current)))
                {
                    result.Remove(result[i]);
                }
            }
            if (result.Count > 0)
            { result.Sort(); }
            return result;
        }
        public IEnumerator GetEnumerator()
        {
            return collectin_of_lines.GetEnumerator();
        }
    } 
}
