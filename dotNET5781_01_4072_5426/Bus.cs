using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace dotNET5781_01_4072_5426
{
    class bus
    {
        public int Mileage { set { if (value >= 0) Mileage = value; else Mileage = -value; } }
        public DateTime Dateofstart;
        //private DateTime last_treatment { set { last_treatment = Dateofstart; } }
        private string license_number;
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
        private bool cheke_General_treatment(int mileage,DateTime last_treatment)
        {
            if (mileage >= 20000) return true;
            else if ((DateTime.Now.Year - last_treatment.Year) == 1) return true;
            else return false;
        }
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
    }
}
