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
        public static DalApi.DO.Line CloneLine(DalApi.DO.Line line)
        {
            DalApi.DO.Line CopyToObject = new DalApi.DO.Line();
            CopyToObject.Id = line.Id;
            CopyToObject.Code = line.Code;
            CopyToObject.Area = line.Area;
            CopyToObject.FirstStation = line.FirstStation;
            CopyToObject.LastStation = line.LastStation;
            return CopyToObject;
        }
       
        public static T Clone<T>(this T original) where T : new()
        {
            T copyToObject = new T();
            //T copyToObject = (T)Activator.CreateInstance(typeof(T));

            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                propertyInfo.SetValue(copyToObject, propertyInfo.GetValue(original, null), null);
            

            return copyToObject;
        }
    }
}
