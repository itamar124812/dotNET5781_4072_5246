using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace dotNET5781_01_4072_5426
{
    class bus
    {
        
        //The length of trips made since the last refueling
        private int refull;
        //The time since the last refueling
        private DateTime last_treatment;
        // the public version for the time since the last refueling
        public DateTime l_t{   set { last_treatment = Dateofstart; }get { return last_treatment; } }
        //the private and  the puclic version for the mailage
        private int Mileage;
        public int mailage { set { if (value >= 0) Mileage = value; else Mileage = -value; }get { return Mileage; }}
       //date of start activity
        private DateTime Dateofstart;
       // the licence number private version 
        private string license_number;
        //The length of trips made since the last treatment
        private int from_last_treatment;
        public int f_l_t { get { return from_last_treatment; } }
        //constructor without Parameters
        public bus ()
        {
            Console.WriteLine("Enter the start date of the activity:");
            string input = Console.ReadLine();
            DateTime.TryParse(input, out Dateofstart);
            input = null;
            try
            {
                Console.WriteLine("Enter the license number as follows 00-000-00 or 000-00-000 :");
                l_n = Console.ReadLine();
            }
            catch (Exception e) { Console.WriteLine(e);return; }
            Console.WriteLine("Entar the milage number:");
            input = Console.ReadLine();
            int a = 0;
            int.TryParse(input, out a);
            mailage = a;
            input = null;
            from_last_treatment = 0;
            refull = 0;
        }
        //  constructor for set  Parameters
        public bus(string lisence_bus,int REfull,int Mailage,int f_lt ,DateTime startDate) 
        {
            Dateofstart = startDate;
            DateTime A = new DateTime(2019, 1, 1);
            if (cheke_l_num(A, lisence_bus))
            {
                license_number = lisence_bus;
                refull = REfull;
                mailage = Mailage;
                from_last_treatment = f_lt;
            }
            else throw new ArgumentException("The lisence number was invalid.");
        }
        //the public and the call for the check for the license number
        public string l_n
        {
            set
            {
                DateTime date = new DateTime(2018, 1, 1);
                {
                    if (cheke_l_num(date,value)) license_number =value ;
                    else throw new Exception("The number is invalid.");
                }
            }
            get { return license_number; }
        }
        //general treatment test
        public bool check_General_treatment(int mileage)
        {
            if ((from_last_treatment + mileage) >= 20000) return true;
            else if ((DateTime.Now.Year - last_treatment.Year) == 1) return true;
            else return false;
        }
        //make a trip
        protected void make_a_trip(int len)
        {
           Mileage +=len;
           from_last_treatment += len;
           refull += len;
            
        }
        //Fuel test
        public bool Refull(int len)
        {
            if ((len + refull) > 1200)
                return false;
            else return true;
        }
        // Confirmation of the correctness of the license number
        private bool cheke_l_num(DateTime date,string l_n)
        {
            if (date <= Dateofstart)
            {
                if (l_n.Length > 10) return false;
                for (int i = 0; i < 10; i++)
                {

                    if (i == 3|| i == 6)
                    {
                        if (!(l_n[i].Equals('-')))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        for(int j=48;j<58;j++)
                        {
                            if ((int)l_n[i]==j ) break;
                            else if (j == 57) return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                if (l_n.Length > 9) return false;
                for (int i = 0; i < 9; i++)
                {

                    if (i == 2 || i == 6)
                    {
                        if (!(l_n[i].Equals('-')))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        for (int j = 48; j < 58; j++)
                        {
                            if ((int)l_n[i]==j) break;
                            else if (j == 57) return false;
                        }
                    }
                }
                return true;
            }
        }
        protected void make_a_refull()
        {
            refull = 0;
            
        }
        public void make_a_treatment()
        {
            last_treatment = DateTime.Now;
            from_last_treatment = 0;
        }

          
    }
}
