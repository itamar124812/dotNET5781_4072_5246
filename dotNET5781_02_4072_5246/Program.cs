using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET5781_02_4072_5246
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice=0;
            bool flag = true;
            while(flag)
            {
                int secondchoice;
                Console.WriteLine("enter 1 for addition, 2 for Deletion, 3 for search, 4 for exit:");
                string input = Console.ReadLine();
                int.TryParse(input, out choice);
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Select 1 to add a new bus line or 2 for add a new station");
                        input = null;
                        input = Console.ReadLine();
                        int.TryParse(input, out secondchoice);
                        if (secondchoice == 1)
                        {

                        }
                        else if (secondchoice == 2)
                        {

                        }
                        else Console.WriteLine("The input was invalid");
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("This number is invalid.");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
