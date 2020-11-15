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
                            int staion_num;
                            Console.WriteLine("Which line would you like to add a station to? Enter the line number:");
                            input = null;
                            input = Console.ReadLine();
                            int.TryParse(input, out secondchoice);
                            int line_num = secondchoice;
                            if (Bus_system_manager.check_line(line_num))
                            {
                                Console.WriteLine("Enter the station number:");
                                input = null;
                                input = Console.ReadLine();
                                int.TryParse(input, out staion_num);
                                Console.WriteLine("If the additional station is new to the entire system, press 1 If the station already exists in the system, press 2:");
                                input = null;
                                input = Console.ReadLine();
                                int.TryParse(input, out secondchoice);
                                if (secondchoice == 1)
                                {
                                    Console.WriteLine("If the new station is at the top of the line Press 1 If the station is in the middle or end of the line Press 2:");
                                    input = null;
                                    input = Console.ReadLine();
                                    int.TryParse(input, out secondchoice);
                                    if (!Check_station(Bus_system_manager, staion_num))
                                    {
                                        Add_station(Bus_system_manager, ref secondchoice, ref input, staion_num, line_num);
                                        Bus_system_manager.existind_stations[staion_num] = true;
                                    }
                                    else Console.WriteLine("There is already such a station.");
                                }
                                else if (secondchoice == 2)
                                {
                                    if (Check_station(Bus_system_manager, staion_num))
                                    {
                                        Add_station(Bus_system_manager, ref secondchoice, ref input, staion_num, line_num);
                                    }
                                    else Console.WriteLine("The station does not exist.");
                                }
                                else Console.WriteLine("the input was invalid");
                            }
                            else Console.WriteLine("The line does not exist.");
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

                            if (Bus_system_manager.existind_stations[temp] == true)
                                Bus_system_manager.existind_stations[temp] = false;

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
                        int g;
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
                            foreach (LineBus i in Bus_system_manager)
                            {
                                Console.WriteLine(i.ToString());
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

        private static void Add_station(CollectionBusLines Bus_system_manager, ref int secondchoice, ref string input, int staion_num, int line_num)
        {
            if (!Check_station(Bus_system_manager, staion_num))
            {
                if (secondchoice == 1) { Bus_system_manager.collectin_of_lines[line_num].enter_head(staion_num); }
                else if (secondchoice == 2)
                {
                    Console.WriteLine(Bus_system_manager.collectin_of_lines[line_num].ToString(), "/n These are the line stations. Select one of the stations and enter the station number to enter the new station after it.");
                    input = null;
                    input = Console.ReadLine();
                    int.TryParse(input, out secondchoice);
                    BusLineStation A = new BusLineStation(secondchoice);
                    if (Bus_system_manager.collectin_of_lines[line_num].cheke_station(A))
                    {
                        int index = Bus_system_manager.collectin_of_lines[line_num].Search_Starion(A);
                        Bus_system_manager.collectin_of_lines[line_num].enter_a_new_stop(Bus_system_manager.collectin_of_lines[line_num].The_line_bus[index], staion_num);

                    }
                    else Console.WriteLine("The station does not exist on the requested line.");
                }
                else Console.WriteLine("The input was invalid.");
            }
            else
            {
                if(secondchoice==1)
                {
                    Bus_system_manager.collectin_of_lines[line_num].enter_head(Bus_system_manager.return_station(staion_num));
                }
                else if(secondchoice==2)
                {
                    Console.WriteLine(Bus_system_manager.collectin_of_lines[line_num].ToString(), "/n These are the line stations. Select one of the stations and enter the station number to enter the new station after it.");
                    input = null;
                    input = Console.ReadLine();
                    int.TryParse(input, out secondchoice);
                    BusLineStation A = new BusLineStation(secondchoice);
                    if (Bus_system_manager.collectin_of_lines[line_num].cheke_station(A))
                    {
                         BusLineStation B=  Bus_system_manager.return_station(staion_num);
                        int index = Bus_system_manager.collectin_of_lines[line_num].Search_Starion(A);
                        Bus_system_manager.collectin_of_lines[line_num].enter_a_new_stop(Bus_system_manager.collectin_of_lines[line_num].The_line_bus[index], staion_num);
                        Bus_system_manager.collectin_of_lines[line_num].The_line_bus[index + 1] = B;
                    }
                }
            }
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
                        another_variable = 10;
                    }
                    else Console.WriteLine("The station already exists. Try again.");
                } while (another_variable == 1);
                another_variable = 1;
            }
            else if (another_variable == 2)
            {
                do
                {
                    Console.WriteLine("Enter the number of the first station where the line will pass:");
                    input = null;
                    input = Console.ReadLine(); secondchoice = 0;
                    int.TryParse(input, out secondchoice);
                    if (Check_station(Bus_system_manager, secondchoice))
                    {
                        A.enter_head(Bus_system_manager.return_station(secondchoice));
                    }
                    else
                    {
                        Console.WriteLine("No such station was found. Please try again:");
                    }
                } while (!(Check_station(Bus_system_manager, secondchoice)));
            }
            else { Console.WriteLine("The input was invalid"); secondchoice=0; return; }
            Console.WriteLine(" If the station is new press 1 if not press 2:");
            input = null;
            input = Console.ReadLine();
            int.TryParse(input, out secondchoice);
            if (secondchoice == 1)
            {
                Console.WriteLine("Please enter the number of the second stop:");
                input = null;
                input = Console.ReadLine();
                int.TryParse(input, out another_variable);
                do
                {
                    if (Bus_system_manager.existind_stations[another_variable] == false)
                    {
                        A.enter_a_new_stop(A.The_line_bus[0], another_variable);
                        Bus_system_manager.existind_stations[another_variable] = true;
                        secondchoice = 10;
                    }
                    else Console.WriteLine("There is already such a station.");
                } while (secondchoice==1);
                secondchoice = 1;
            }
            else if (secondchoice == 2)
            {
                do {
                    Console.WriteLine("Please enter the number of the second stop:");
                    input = null;
                    input = Console.ReadLine();
                    int.TryParse(input, out secondchoice);
                    if (Check_station(Bus_system_manager, secondchoice))
                    {
                        A.enter_a_new_stop(Bus_system_manager.return_station(secondchoice), another_variable);
                    }
                    else Console.WriteLine("No such station was found. Please try again");
                } while (!(Check_station(Bus_system_manager, secondchoice)));
            }
            else Console.WriteLine("The input was invalid"); 
            Bus_system_manager.add(A);
        }

        private static void start_push(CollectionBusLines Bus_system_manager)
        {
            for (int i = 1; i <= 40; i++)
            {
                LineBus temp = new LineBus(i);
                Bus_system_manager.add(temp);

                BusLineStation temp1 = new BusLineStation(i);
                Bus_system_manager.collectin_of_lines[i - 1].enter_head(temp1);
                Bus_system_manager.existind_stations[i] = true;


            }
            for (int z = 1; z <= 10; z++)
            {
                BusLineStation a = Bus_system_manager.return_station(z);
                Bus_system_manager.collectin_of_lines[z+29].enter_head(a);
            }
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
