using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DalApi
{
    public interface IDal
    {
        #region user
        DO.User GetUser(string user);
        void AddUser(DO.User user);
        void DeleteUser(string user);
        #endregion
        #region Trip
        DO.Trip GetTrip(int ID);
        void AddTrip();
        #endregion
        #region Bus
        void AddBus(int LicenseNum, DateTime StartDate, double refull, int status);
        DO.Bus GetBus(int LicenseNum);
        void DeleteBus(int LicenseNum);
        #endregion
        #region Station

        #endregion
    }
}
