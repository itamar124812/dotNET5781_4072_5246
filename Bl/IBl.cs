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
        
       void AddLine(int CodeLine,int area,int LastStation);
        void AddStationToLine(int LineCode, int Numstation,int index);
        IEnumerable<LineBus> GetsAllLines();
        IEnumerable<LineBus> GetSpecificLines(Predicate<LineBus> predicate);
        IEnumerable<LineBus> GetBusFromArea(int area);
        LineBus GetLine(int LineCode);
        void DeleteLine(int LineCode);
        #endregion
        #region Stations
        void DeleteStations(int StationCode);
        void ADDStation(double latitude, double longitude, int codeStation , String name );
       

        #endregion

    }
}
