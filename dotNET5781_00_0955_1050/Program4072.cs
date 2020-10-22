using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET5781_00_0955_1050
{
    partial class Program
    {
        static void Main(string[] args)
        {
            welcome_4072();
            welcome_5426();
            Console.ReadKey();
        }
        static partial void welcome_5426();
        private static void welcome_4072()
        {
            Console.WriteLine("enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", name);
        }
    }
}
