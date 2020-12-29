using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DalApi.DO;
using DS;


namespace DalObject
{
    class DalObject : IDal
    {
        #region Singelton
        static readonly DalObject instance = new DalObject();
        static DalObject() { }
        DalObject() { } 
        public static DalObject Instance { get => instance; }
        #endregion
        #region Bus
        public void AddBus(DalApi.DO.Bus bus)
        {
            if (DS.DataSource.ListBuses.Find(b => b.LicenseNum == bus.LicenseNum) != null)
            {
                throw new DalApi.DO.BadBusException(bus.LicenseNum, "There is already a bus with the same license number:");
            }
            DataSource.ListBuses.Add(bus.Clone());
        }
        public void DeleteBus(int LicenseNum)
        {
            DalApi.DO.Bus RemuveBus = DS.DataSource.ListBuses.Find(b => b.LicenseNum == LicenseNum);
            if (RemuveBus != null)
            {
                DS.DataSource.ListBuses.Remove(RemuveBus);
            }
            else throw new DalApi.DO.BadBusException(LicenseNum, "The bus does not exist . license number:");
        }
        public IEnumerable<Bus> GetAllBuses()
        {
            return from DalApi.DO.Bus bus in DS.DataSource.ListBuses
                   select bus.Clone();
         }
        public Bus GetBus(int LisenceNum)
        {
          DalApi.DO.Bus bus =  DataSource.ListBuses.Find(b => b.LicenseNum == LisenceNum);
            if (bus != null)
                return bus.Clone();
            else throw new DalApi.DO.BadBusException(LisenceNum, "The bus does not exist . license number:");
        }
        #endregion
        #region BusOnTrip
        public void AddBusOnTrip(DalApi.DO.BusOnTrip trip)
        {
            if(DS.DataSource.ListBusOnTrips.Find(BOT=>BOT.RunningNum ==trip.RunningNum)!=null)
            {
                throw new DalApi.DO.BadBusOnTripException(trip.RunningNum, "Duplicate BusOnTrip Id:");
            }
            DS.DataSource.ListBusOnTrips.Add(trip);
        }
        public void DeleteBusOnTrip(int Id)
        {
            DalApi.DO.BusOnTrip busOnTrip = DataSource.ListBusOnTrips.Find(BOT => BOT.RunningNum == Id);
            if (busOnTrip != null)
                DataSource.ListBusOnTrips.Remove(busOnTrip);
            else throw new DalApi.DO.BadBusOnTripException(Id, "There is no bus Trip with such an identification number:");
                
        }
        public BusOnTrip GetBusOnTrip(int Id)
        {
            DalApi.DO.BusOnTrip busOnTrip= DataSource.ListBusOnTrips.Find(BOT => BOT.RunningNum == Id);
            if (busOnTrip != null)
                return busOnTrip;
            else throw new DalApi.DO.BadBusOnTripException(Id, "There is no bus Trip with such an identification number:");
        }
        #endregion
        #region Station
        public void AddStation(int code, string name, double Longitude, double Latitude)
        {
            throw new NotImplementedException();
        }
        public void DeleteStation(int code)
        {
            throw new NotImplementedException();
        }
        public Station GetStation(int code)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region User
        public void AddUser(DalApi.DO.User user)
        {
           if(DataSource.UsersManager.Find(User=>user.UserName==User.UserName)!=null)
            {
                throw new DalApi.DO.UserExceptions(user.UserName, "Duplicate User UserName:");
            }
            DataSource.UsersManager.Add(user);
        }
        public void DeleteUser(string user)
        {
            throw new NotImplementedException();
        }
        public User GetUser(string user)
        {
            throw new NotImplementedException();
        }
        #endregion
#region Trip
        public void AddTrip()
        {
            throw new NotImplementedException();
        }
        public Trip GetTrip(int ID)
        {
            throw new NotImplementedException();
        }
#endregion

    }
}
