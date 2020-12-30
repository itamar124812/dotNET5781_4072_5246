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
            DS.DataSource.ListBusOnTrips.Add(trip.Clone());
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
                return busOnTrip.Clone();
            else throw new DalApi.DO.BadBusOnTripException(Id, "There is no bus Trip with such an identification number:");
        }
        #endregion
        #region Station
        public void AddStation(DalApi.DO.Station station)
        {
            if (DataSource.ListStations.Find(s => s.Code == station.Code) != null)
            {
                throw new DalApi.DO.StationException(station.Code, "Duplicate Station code.");
            }
            else DataSource.ListStations.Add(station.Clone());

        }
        public void DeleteStation(int code)
        {
            Station station = DataSource.ListStations.Find(S => S.Code == code);
            if (station == null) throw new DalApi.DO.StationException(code, "There is no such station.");
            DataSource.ListStations.Remove(station);
        }
        public Station GetStation(int code)
        {
            Station Result = DataSource.ListStations.Find(S => S.Code == code);
            if(Result!=null) return Result.Clone();
            throw new DalApi.DO.StationException(code, "There is no such station.");
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
        public void DeleteUser(string userName)
        {
            DalApi.DO.User user = DataSource.UsersManager.Find(U => U.UserName == userName);
            if (user == null) throw new DalApi.DO.UserExceptions(userName, "The badUser:");
            else DataSource.UsersManager.Remove(user.Clone());
        }
        public IEnumerable<User> GetAllUsers()
        {
          return  from User user in DataSource.UsersManager
            select user.Clone();
        }
        public User GetUser(string userName)
        {
            DalApi.DO.User result = DataSource.UsersManager.Find(U => U.UserName == userName);
            if (result == null) throw new DalApi.DO.UserExceptions(userName, "The badUser:");
            else return result.Clone();
        }
        #endregion
#region Trip
        public void AddTrip(DalApi.DO.Trip trip)
        {
            if (DataSource.ListTrip.Find(T => T.Id == trip.Id) != null)
                throw new DalApi.DO.TripException(trip.Id, "Duplicate Trip id.");
            DataSource.ListTrip.Add(trip.Clone());
        }
        public void DeleteTrip(int code)
        {
            DalApi.DO.Trip trip = DataSource.ListTrip.Find(T => T.Id == code);
            if (trip != null)
                throw new DalApi.DO.TripException(code, "There is no such trip.");
            DataSource.ListTrip.Remove(trip.Clone());
        }
        public Trip GetTrip(int ID)
        {
            DalApi.DO.Trip trip = DataSource.ListTrip.Find(T => T.Id == ID);
            if (trip != null)
                throw new DalApi.DO.TripException(ID, "There is no such trip.");
            return trip.Clone();
        }
        #endregion
        #region AdjacentStations
        public IEnumerable<AdjacentStations> GetALLAdjacentStations()
        {
            return from DalApi.DO.AdjacentStations AS in DataSource.ListAdjecentStations
                   select AS.Clone();
        }

        public AdjacentStations GetAdjacentStations(Station A, Station B)
        {
            throw new NotImplementedException();
        }

        public void AddAdjacentStations(AdjacentStations adjacentStations)
        {
            throw new NotImplementedException();
        }

        public void DeleteAdjacentStations(Station A, Station B)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
