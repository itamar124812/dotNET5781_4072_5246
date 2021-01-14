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
        
       void AddLine(int CodeLine,int area,int LastStation);
        void AddStationToLine(int Id, int Numstation,int index);
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
        //Need to Imp
        #region Users

        #endregion
        #region Trips
        #endregion
    }
}
