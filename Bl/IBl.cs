using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi.DO;
using DalApi;
using Bl.BO;

namespace Bl
{
     public interface IBl
    {
        #region Lines
        
       void AddLine(int CodeLine);
        void AddStationToLine(int LineCode, int Numstation,int index);
        IEnumerable<LineBus> GetsAllLines();
        IEnumerable<LineBus> GetSpecificLines(Predicate<DalApi.DO.LineStation> predicate);
        IEnumerable<LineBus> GetBusFromArea(int area);
        LineBus GetLine();
        void DeleteLine(int LineCode);
        IEnumerable<LineStation> GetStationsInLine(int lineCode);
        #endregion
        #region Stations
        void DeleteStations(int StationCode);
        void ADDStation(double latitude, double longitude, int codeStation , String name );
       

        #endregion

    }
}
