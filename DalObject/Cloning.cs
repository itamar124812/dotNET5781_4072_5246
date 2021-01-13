using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DalObject
{
    public static  class Cloning
    {
       
        public static T Clone<T>(this T original) where T : new()
        {
            T copyToObject = new T();
            //T copyToObject = (T)Activator.CreateInstance(typeof(T));

            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                propertyInfo.SetValue(copyToObject, propertyInfo.GetValue(original, null), null);
            foreach (var item in typeof(T).GetFields())
            {
                item.SetValue(original, item.GetValue(original));
            }
         
            return copyToObject;
        }
    }
}
