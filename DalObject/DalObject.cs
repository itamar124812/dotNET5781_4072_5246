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
        static readonly DalObject instance = new DalObject();
        static DalObject() { }
        DalObject() { } 
        public static DalObject Instance { get => instance; }
        public void AddBus(int LicenseNum, DateTime StartDate,int Kilometrash, double refull, int status)
        {
            foreach (Bus item in DS.DataSource.ListBuses)
            {
                if(LicenseNum==item.LicenseNum)
                {
                    
                }
            }
            Bus A = new Bus();
            A.LicenseNum = LicenseNum;
            A.FromDate = StartDate;
            A.FuelRemain = refull;
            A.TotalTrip = Kilometrash;
            A.Status = (BusStatus)status;
            DS.DataSource.ListBuses.Add(A.Clone());
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
