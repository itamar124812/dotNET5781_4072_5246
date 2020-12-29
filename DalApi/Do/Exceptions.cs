using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi.DO
{
   public class BadBusException:Exception
    {
       int LicenseNum;
       public   BadBusException(int licenseNum) : base() => LicenseNum = licenseNum;
       public  BadBusException(int licenseNum, string message) : base(message) => LicenseNum = licenseNum;
        public override string ToString()
        {
            string result = base.ToString();
            result += LicenseNum.ToString();
            return result;
        }
    }
    public class BadBusOnTripException:Exception
    {
        int id;
        public BadBusOnTripException(int Id, string message) : base(message) => id = Id;
        public override string ToString()
        {
            string result = base.ToString();
            result += string.Format("BadBasOnTrip:{0}", id);
            return result;
        }
    }
    public class UserExceptions:Exception
    {
        string UserName;
        public UserExceptions(string userName, string message) : base(message) => UserName = userName;
        public override string ToString()
        {
            return base.ToString() + UserName;
        }
    }
}
