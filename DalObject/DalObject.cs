using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DalApi.DO;


namespace DalObject
{
    class DalObject : IDal
    {
        public void AddBus(int LicenseNum, DateTime StartDate, double refull, int status)
        {
            throw new NotImplementedException();
        }

        public void AddBusOnTrip(int licenseNum, int Lineld, TimeSpan PlannedTakeOff, TimeSpan ActualTakeOff, int PrevStation, TimeSpan PrevStationA1, TimeSpan NextStationA1)
        {
            throw new NotImplementedException();
        }

        public void AddStation(int code, string name, double Longitude, double Latitude)
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

        public void DeleteBusOnTrip(int Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteStation(int code)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bus> GetAllBuses()
        {
            throw new NotImplementedException();
        }

        public Bus GetBus(int LisenceNum)
        {
            throw new NotImplementedException();
        }

        public BusOnTrip GetBusOnTrip(int Id)
        {
            throw new NotImplementedException();
        }

        public Station GetStation(int code)
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
