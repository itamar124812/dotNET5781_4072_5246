using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace dotNET5781_02_4072_5246
{
    
    class Program
    {
        static void Main(string[] args)
        {

            int choice = 0;
            CollectionBusLines Bus_system_manager = new CollectionBusLines();
            //start_push(Bus_system_manager);
            bool flag = true;
            while (flag)
            {
                int secondchoice,another_variable;
                Console.WriteLine("enter 1 for addition, 2 for Deletion, 3 for search, 4 for print, 5 for exit:");
                string input = Console.ReadLine();
                int.TryParse(input, out choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Select 1 to add a new bus line or 2 for add a new station");
                        input = null;
                        input = Console.ReadLine();
                        int.TryParse(input, out secondchoice);
                        if (secondchoice == 1)
                        {
                            try
                            {
                                addline(Bus_system_manager, out secondchoice, out another_variable, out input);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            
                        }
                        else if (secondchoice == 2)
                        {
                            Console.WriteLine("Which line would you like to add a station to? Enter the line number:");
                            input = null;
                            input = Console.ReadLine();
                            int.TryParse(input, out secondchoice);
                            int temp = secondchoice;
                            Console.WriteLine("If the additional station is the first station Press 1 If not press 2:");
                            input = null;
                            input = Console.ReadLine();
                            int.TryParse(input, out secondchoice);
                            try
                            {
                                LineBus Auxiliary_variable = Bus_system_manager.find(temp);
                                if (secondchoice == 1)
                                {
                                    Auxiliary_variable.enter_head(0);                               
                                    Bus_system_manager.remove(secondchoice);
                                    Bus_system_manager.add(Auxiliary_variable);
                                }
                                else if (secondchoice == 2)
                                {
                                    BusLineStation A = new BusLineStation();
                                    Auxiliary_variable.enter_a_new_stop(A,0);
                                    Bus_system_manager.remove(secondchoice);
                                    Bus_system_manager.add(Auxiliary_variable);
                                  
                                }
                                else Console.WriteLine("The input was invalid.");
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else Console.WriteLine("The input was invalid");
                        break;
                    case 2:
                        Console.WriteLine("What would you like to delete? Press 1 to delete a bus line and 2 to delete a bus stop:");
                        input = null;
                        input = Console.ReadLine();
                        int.TryParse(input, out secondchoice);
                        if (secondchoice == 1)
                        {
                            try
                            {
                                Console.WriteLine("Enter the line number you want to delete:");
                                input = null;
                                input = Console.ReadLine();
                                int.TryParse(input, out secondchoice);
                                if (Bus_system_manager.check_line(secondchoice))
                                {
                                    Bus_system_manager.remove(secondchoice);
                                }
                                else Console.WriteLine("There is no such line in the system.");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else if (secondchoice == 2)
                        {
                            int temp = 0;
                            Console.WriteLine("Which line would you like to add a station to? Enter the line number:");
                            input = null;
                            input = Console.ReadLine();
                            int.TryParse(input, out temp);
                            Console.WriteLine("Enter the station number you want to delete:");
                            input = null;
                            input = Console.ReadLine();
                            int.TryParse(input, out secondchoice);
                            try
                            {
                                LineBus Auxiliary_variable = Bus_system_manager.find(temp);
                                Auxiliary_variable.remove_station(secondchoice);
                                Bus_system_manager.remove(temp);
                                Bus_system_manager.add(Auxiliary_variable);
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Choose which search you want to perform? To check which buses pass through the station, click 1 To search for the route to a specific destination, click 2:");
                        input = null;
                        input = Console.ReadLine();
                        int.TryParse(input, out secondchoice);
                        if (secondchoice == 1)
                        {
                            Console.WriteLine("Enter your destination station number:");
                            input = null;
                            input = Console.ReadLine();
                            int.TryParse(input, out secondchoice);
                            try
                            {
                                List<LineBus> result = Bus_system_manager.passing_through(secondchoice);
                                Console.WriteLine(result.ToString());
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else if (secondchoice == 2)
                        {
                            Console.WriteLine("Enter your departure  number station:");
                            input = null;
                            input = Console.ReadLine();
                            int.TryParse(input, out secondchoice);
                            if (Check_station(Bus_system_manager, secondchoice))
                            {
                                BusLineStation departure = new BusLineStation(secondchoice);
                                Console.WriteLine("Enter your destination  number station:");
                                input = null;
                                input = Console.ReadLine();
                                int.TryParse(input, out secondchoice);
                                if (Check_station(Bus_system_manager, secondchoice))
                                {
                                    BusLineStation destination = new BusLineStation(secondchoice);
                                    List<LineBus> result = Bus_system_manager.Finding_an_optimal_route(departure, destination);
                                    for (int i = 0; i < result.Count; i++)
                                    {
                                        result[i].ToString();
                                    }
                                }
                                else Console.WriteLine("There is no such station");
                            }
                            else Console.WriteLine("There is no such station");

                        }
                        else Console.WriteLine("the input was invalid.");

                        break;
                    case 4:
                        Console.WriteLine("What would you like to print? Select 1 to print all buses and 2 to see which stations cross which lines:");
                        input = null;
                        input = Console.ReadLine();
                        int.TryParse(input, out secondchoice);
                        if (secondchoice == 1)
                        {
                            foreach (LineBus A in Bus_system_manager)
                            {
                                area b = (area)A.AREA;
                                Console.WriteLine("Line number: {0}   area:{1}.", A.bus_line_key, b);
                            }
                        }
                        else if (secondchoice == 2)
                        {
                           
                        }
                        else Console.WriteLine("The input was invalid");
                        break;
                    case 5:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("This number is invalid.");
                        break;
                }
            }
            Console.ReadKey();
        }

        private static void addline(CollectionBusLines Bus_system_manager, out int secondchoice, out int another_variable, out string input)
        {
            Console.WriteLine("What is the bus line number you would like to add?");
            input = Console.ReadLine();
            int temp, temp1;
            int.TryParse(input, out temp);
            Console.WriteLine("pleae select area:0 for  general,1 for North,2 for South, 3 for Center,4 for Jerusalem");
            input = Console.ReadLine();
            int.TryParse(input, out temp1);
            LineBus A = new LineBus(temp, temp1);
            Console.WriteLine("If it's a new station Press 1 If the station already exists Press 2:");
            input = null;
            input = Console.ReadLine(); int.TryParse(input, out another_variable);
            if (another_variable == 1)
            {
                do
                {
                    Console.WriteLine("Enter the number of the first station where the line will pass:");
                    input = null;
                    input = Console.ReadLine(); secondchoice = 0;
                    int.TryParse(input, out secondchoice);
                    if (!Bus_system_manager.existind_stations[secondchoice])
                    {
                        A.enter_head(secondchoice);
                        Bus_system_manager.existind_stations[secondchoice] = true;
                    }
                    else Console.WriteLine("The station already exists. Try again.");
                } while (!Bus_system_manager.existind_stations[secondchoice]);
            }
            else if (another_variable == 2)
            {
                Console.WriteLine("Enter the number of the first station where the line will pass:");
                input = null;
                input = Console.ReadLine(); secondchoice = 0;
                int.TryParse(input, out secondchoice);
                if (Check_station(Bus_system_manager, secondchoice))
                {
                    A.enter_head(Bus_system_manager.return_station(secondchoice));
                }
            }
            else Console.WriteLine("The input was invalid");
            Console.WriteLine("Please enter the number of the second stop:");
            input = null;
            input = Console.ReadLine();
            int.TryParse(input, out another_variable);
            Console.WriteLine(" If the station is new press 1 if not press 2:");
            input = null;
            input = Console.ReadLine();
            int.TryParse(input, out secondchoice);
            if (secondchoice == 1)
            {
                if (Bus_system_manager.existind_stations[another_variable] == false)
                {
                    A.enter_a_new_stop(A.The_line_bus[0], another_variable);
                    Bus_system_manager.existind_stations[another_variable] = true;
                }
                else Console.WriteLine("There is already such a station.");
            }
            else if (secondchoice == 2)
            {
                if (Check_station(Bus_system_manager, secondchoice))
                {
                    A.enter_a_new_stop(Bus_system_manager.return_station(secondchoice), another_variable);
                }
            }
            else Console.WriteLine("The input was invalid");
            Bus_system_manager.add(A);
        }

        private static void start_push(CollectionBusLines Bus_system_manager)
        {
            for (int i = 0; i < 10; i++)
            {
                LineBus temp = new LineBus(i);
                BusLineStation B = new BusLineStation();
                temp.The_line_bus.Add(B);
                Bus_system_manager.add(temp);
            }
        }

        private static void Treatment_duplication_station(CollectionBusLines Bus_system_manager, LineBus A)
        {
        }


       

       private static bool Check_station(CollectionBusLines Bus_system_manager, int bus_code)
        {
            if (bus_code < 1000000 && bus_code > 0)
            {
                if (Bus_system_manager.existind_stations[bus_code] == true)
                {
                    return true;
                }
                else return false;
            }
            else return false;
       }
    }

       
    
}
