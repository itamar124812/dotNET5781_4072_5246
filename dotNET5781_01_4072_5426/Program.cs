using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET5781_01_4072_5426
{
    class Program
    {
        static void Main(string[] args)
        {
            bus A = new bus();
            Console.WriteLine("enter a bus");
            try
            {
                string input = Console.ReadLine();
                DateTime.TryParse(input, out A.Dateofstart);
                A.l_n = Console.ReadLine();
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
            Console.WriteLine(A.l_n);
            Console.ReadKey();
        }
        
    }
}
