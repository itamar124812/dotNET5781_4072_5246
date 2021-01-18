using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DalApi;
using DalApi.DO;

namespace DalXml
{
    class DalXml : IDal
    {
        #region singelton
        static readonly DalXml instance = new DalXml();
        static DalXml() { }// static ctor to ensure instance init is done just before first usage
        DalXml() { } // default => private
        public static DalXml Instance { get => instance; }// The public Instance property to use
        #endregion
        #region AdjacentStations
        public void AddAdjacentStations(AdjacentStations adjacentStations)
        {
            throw new NotImplementedException();
        }
        public void DeleteAdjacentStations(Station A, Station B)
        {
            throw new NotImplementedException();
        }
        public AdjacentStations GetAdjacentStations(Station A, Station B)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<AdjacentStations> GetALLAdjacentStations()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Buses
        public Bus GetBus(int LicenseNum)
        {
            throw new NotImplementedException();
        }
        public void AddBus(Bus bus)
        {
            throw new NotImplementedException();
        }
        public void DeleteBus(int LicenseNum)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Bus> GetAllBuses()
        {
            throw new NotImplementedException();
        }
        #endregion 
        #region BusOnTrip
        public void AddBusOnTrip(BusOnTrip Trip)
        {
            throw new NotImplementedException();
        }
        public void DeleteBusOnTrip(int Id)
        {
            throw new NotImplementedException();
        }
        public BusOnTrip GetBusOnTrip(int Id)
        {
            throw new NotImplementedException();
        }
        #endregion 
        #region Lines
        public void UpdateCode(int id, int newcode)
        {
            throw new NotImplementedException();
        }
        public void AddLine(Line line)
        {
            throw new NotImplementedException();
        }
        public void DeleteLine(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Line> GetAllLines()
        {
            throw new NotImplementedException();
        }
        public Line GetLine(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region LineStation
        public void AddLineStation(LineStation lineStation)
        {
            throw new NotImplementedException();
        }
        public void DeleteLineStation(int LineNum, int StationNum)
        {
            throw new NotImplementedException();
        }
        public LineStation GetLineStation(int LineNum, int StationNum)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<LineStation> GetsAllStationInLine(int LineNum)
        {
            throw new NotImplementedException();
        }
        public void Update(LineStation station, bool PlusOrMinus)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region LineTrip
        public void UpdateStartTime(int Id, TimeSpan time)
        {
            throw new NotImplementedException();
        }
        public LineTrip GetLineTrip(int LineNumber, TimeSpan startAt)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<LineTrip> GetsAllTripsForLine(int LineNumber)
        {
            throw new NotImplementedException();
        }

        public void AddLineTrip(LineTrip lineTrip)
        {
            throw new NotImplementedException();
        }
        public void DeleteLineTrip(int LineNumber, TimeSpan startAt)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Stations
        public void AddStation(Station station)
        {
            throw new NotImplementedException();
        }
        public void DeleteStation(int code)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Station> GetAllStations()
        {
            throw new NotImplementedException();
        }
        public Station GetStation(int code)
        {
            throw new NotImplementedException();
        }
        #endregion       
        #region Users
        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }
        public void DeleteUser(string user)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }
        public User GetUser(string Name)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Trips
        public void AddTrip(Trip trip)
        {
            throw new NotImplementedException();
        }
        public void DeleteTrip(int Id)
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
