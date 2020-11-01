using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace dotNET5781_01_4072_5426
{
    //enum choice {Newbus, Arrange_a_new_trip, Refuel_or_treatment, Recent_trips, Exit }
    class Program
    {
        static void Main(string[] args)
        {
            List<bus> Buses= new List<bus> ();
            bool flag = true;
            int Choice = 0;
            while (flag)
            {
                Console.WriteLine("Please select one of the following options:\n1.for enter a new bus:\n2.for arrange a new trip:");
                //I started a new line for convenience
                Console.WriteLine("3.make refuel or treatment:\n4.watch at recent trips:\n5. for Exit: ");
                string input = Console.ReadLine();
                int.TryParse(input, out Choice);
                //Input test
                while (Choice<1|| Choice >5)
                {
                    Console.WriteLine("The number  is incorrect. Please enter a new one: ");
                    string Input = Console.ReadLine();
                    int.TryParse(Input, out Choice);
                }
                //the switch case
                switch(Choice)
                {
                    case 1:
                        //create a new bus and add to buses
                        bus A = new bus();
                        Buses.Add(A);
                        break;
                    case 2:
                        //make a trip
                        Console.WriteLine("Please enter the license number that you want to select as follows 00-000-00 or 000-00-000 :");
                        string Input = Console.ReadLine();
                        if (Find_license_num(Input, Buses))
                        {
                            Random r = new Random(DateTime.Now.Millisecond);
                          int ran= r.Next(0, 1200);
                            
                            bus retuenbus = find_a_bus(Input, Buses);
                           if( !(retuenbus.check_General_treatment(ran)))
                           {
                                if (retuenbus.Refull(ran)) retuenbus.make_a_trip(ran);
                                else Console.WriteLine("You do not have enough fuel.");break;
                           }
                            else {
                                Console.WriteLine("The bus needs general treatment"); break; 
                            }

                        }
                        else Console.WriteLine("The bus does not exist in the system");
                        break;
                    case 3:

                        break;
                    case 4:
                       
                        break;
                    case 5:
                        flag = false;
                        break;
                }
            }

        }
        //search for the bus in the list by the license num
        private static bool Find_license_num(string input, List<bus> A)
        {
            foreach (bus a in A)
            {
                if (a.l_n == input)
                {
                    return true;
                }
            }
            return false;
        }
        //the some search with ubmit the requested bus
        public static bus find_a_bus(string L_n,List<bus> A)
        {
            bus B=new bus(5);
            foreach(bus a in A)
            {
                if(a.l_n==L_n)
                {
                    B = a;
                }
            }
            return B;
        }
    }
   
}
