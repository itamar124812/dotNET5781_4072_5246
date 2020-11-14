using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;//כדי לממש את הממשק IEnumerable
namespace dotNET5781_02_4072_5246
{
    
    class CollectionBusLines : IEnumerable
    {
        
        List<LineBus> collectin_of_lines = new List<LineBus>();//יצירת אוסף של קווי האוטובוסים
        public void add()
        {
            LineBus A = new LineBus();
            collectin_of_lines.Add(A);
        }
        public void remove(LineBus a)
        {
            collectin_of_lines.Remove(a);
        }
         public LineBus Mthud (int code)
        {
            bool flag = false;//לבדוק אם צריך חריגה או לא
            LineBus b = new LineBus();//הרישמה שבהם יש את הcode
            foreach(LineBus i in collectin_of_lines)
            {
                if(i.bus_line_key==code)//פה צריך מזהה )קוד( של תחנת אוטובוס
                {

                    b.Add(i);//צריך תיקון
                    flag = true;
                }
                
            }
            if(flag == false)
            {
                throw new ArgumentException("There are no lines passing through the station");
            }
            return b; 
        }

        //צריך לעשות מיון וצריך לשאול מה זה זמן נסיעה
        //מקבל את מספר הקו ומחזיר את המופע

        public IEnumerator GetEnumerator()
        {
            return collectin_of_lines.GetEnumerator();
        }
    }
}
