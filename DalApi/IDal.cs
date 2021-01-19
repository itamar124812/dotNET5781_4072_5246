using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi.DO;

namespace DalApi
{
    public interface IDal
    {
        #region user
        DO.User GetUser(string user);
        void AddUser(DO.User user);
        void DeleteUser(string user);
        IEnumerable<User> GetAllUsers();
        #endregion
        #region Trip
        DO.Trip GetTrip(int ID);
        void AddTrip(DO.Trip trip);
        void DeleteTrip(int Id);
        #endregion
        #region Bus
        IEnumerable<DO.Bus> GetAllBuses();
        void AddBus(DO.Bus bus);
        DO.Bus GetBus(int LicenseNum);
        void DeleteBus(int LicenseNum);
        #endregion
        #region Station
        void AddStation(DO.Station station);
        void DeleteStation(int code);
        DO.Station GetStation(int code);
        IEnumerable<Station> GetAllStations();
        #endregion
        #region BusOnTrip
        void AddBusOnTrip(DO.BusOnTrip Trip );
        void DeleteBusOnTrip(int Id);
        DO.BusOnTrip GetBusOnTrip(int Id);
        #endregion
        #region AdjacentStations
        IEnumerable<AdjacentStations> GetALLAdjacentStations();
        AdjacentStations GetAdjacentStations(Station A, Station B);
        void AddAdjacentStations(AdjacentStations adjacentStations);
        void DeleteAdjacentStations(Station A, Station B);
        #endregion
        #region Line
        void AddLine(Line line);
        void DeleteLine(int id);
        Line GetLine(int id);
        IEnumerable<Line> GetAllLines();
        void UpdateCode(int id, int newcode);
        #endregion
        #region LineStation
        void AddLineStation(LineStation lineStation);
        void DeleteLineStation(int LineNum, int StationNum);
        LineStation GetLineStation(int LineNum, int StationNum);
        IEnumerable<LineStation> GetsAllStationInLine(int LineNum);
        void Update(LineStation station , bool PlusOrMinus);
        #endregion
        #region LineTrip
        void UpdateStartTime(int Id,TimeSpan OldTime ,TimeSpan NewTime);
        void AddLineTrip(LineTrip lineTrip);
        void DeleteLineTrip(int LineNumber, TimeSpan startAt);
        LineTrip GetLineTrip(int LineNumber, TimeSpan startAt);
        IEnumerable<LineTrip> GetsAllTripsForLine(int LineNumber);
        #endregion
    }
}
