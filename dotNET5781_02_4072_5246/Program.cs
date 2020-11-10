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
            start_push(Bus_system_manager);
            bool flag = true;
            while (flag)
            {
                int secondchoice;
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
                                Bus_system_manager.add();
                                Treatment_duplication_station(Bus_system_manager);
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
                                    Auxiliary_variable.enter_head();
                                    Treatment_duplication_station(Bus_system_manager);
                                    Bus_system_manager.remove(secondchoice);
                                    Bus_system_manager.add(Auxiliary_variable);
                                }
                                else if (secondchoice == 2)
                                {
                                    BusLineStation A = new BusLineStation();
                                    Auxiliary_variable.enter_a_new_stop(A);
                                    Bus_system_manager.remove(secondchoice);
                                    Bus_system_manager.add(Auxiliary_variable);
                                    Treatment_duplication_station(Bus_system_manager);
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
                            for (int i = 0; i < Bus_system_manager.keys_for_stations.Count; i++)
                            {
                                List<LineBus> result = Bus_system_manager.passing_through(Bus_system_manager.keys_for_stations[i]);
                                for (int j = 0; j < result.Count; j++)
                                {
                                    Console.WriteLine(result[j].ToString());
                                }
                            }
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

        private static void Treatment_duplication_station(CollectionBusLines Bus_system_manager)
        {
            for (int i = 0; i < Bus_system_manager.keys_for_stations.Count; i++)
            {
                for (int j = i + 1; j < Bus_system_manager.keys_for_stations.Count; j++)
                {
                    if (Bus_system_manager.keys_for_stations[i] == Bus_system_manager.keys_for_stations[j])
                        Bus_system_manager.remove(Bus_system_manager.keys_for_stations[j]);
                }
            }
        }
        private static bool Check_station(CollectionBusLines Bus_system_manager, int bus_code)
        {
            for (int i = 0; i < Bus_system_manager.keys_for_stations.Count; i++)
            {
                if (Bus_system_manager.keys_for_stations[i] == bus_code)
                    return true;
            }
            return false;
        }
    }

       
    
}
