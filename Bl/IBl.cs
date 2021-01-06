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
        void AddStationToLine(int LineCode, DalApi.DO.Station station,int index);
        IEnumerable<LineBus> GetsAllLines();
        IEnumerable<LineBus> GetSpecificLines(Predicate<DalApi.DO.LineStation> predicate);
        IEnumerable<LineBus> GetBusFromArea(DalApi.DO.Areas Area);
        LineBus GetLine();
        void DeleteLine(int LineCode);
        #endregion
        #region Stations
        IEnumerable<BusStation> GetAllStation();
       

        #endregion

    }
}
