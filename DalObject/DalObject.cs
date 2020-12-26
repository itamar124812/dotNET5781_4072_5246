using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DalApi.DO;
using DO;

namespace DalObject
{
    class DalObject : IDal
    {
        public void AddBus(int LicenseNum, DateTime StartDate, double refull, int status)
        {
            throw new NotImplementedException();
        }

        public void AddTrip()
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteBus(int LicenseNum)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string user)
        {
            throw new NotImplementedException();
        }

        public Bus GetBus(int LisenceNum)
        {
            throw new NotImplementedException();
        }

        public Trip GetTrip(int ID)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string user)
        {
            throw new NotImplementedException();
        }
    }
}
