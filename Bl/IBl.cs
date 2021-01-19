using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi.DO;
using DalApi;
using Bl.BO;

namespace BlApi
{
     public interface IBl
    {
        #region Lines
        void UpdateLineCode(int id, int NewCode);
       void AddLine(int CodeLine,int area,int LastStation);
        void AddStationToLine(int Id, int Numstation,int index,double distanceFromLastStation,TimeSpan timeFromLastStation);
        IEnumerable<LineBus> GetsAllLines();
        IEnumerable<LineBus> GetSpecificLines(Predicate<LineBus> predicate);
        IEnumerable<LineBus> GetBusFromArea(int area);
        LineBus GetLine(int Id);
        void DeleteLine(int Id);
        #endregion
        #region Stations
        void DeleteStations(int StationCode);
        void ADDStation(double latitude, double longitude, int codeStation , String name );
        BusStation GetAllLinesForStation(int StationCode);
        IEnumerable<BusStation> GetAllStations();
        #endregion
     
        #region Users
        bool IsExists(string UserName);
        bool CheckPassword(string UserName, string password);
        void AddUser(string Name, string Password, bool Admin);
        void DeleteUser(string Name);
        bool IsAdmin(string Name);
        #endregion
       
        #region LinesTrips
        void AddLineTrip(int id, TimeSpan StartTime);
        void DeleteLineTrip(int id, TimeSpan StartTime);
        void UpdateStartTime(int Id,TimeSpan key, TimeSpan StartTime);
        #endregion
    }
}
