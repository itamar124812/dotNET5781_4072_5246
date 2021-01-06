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
        BO.LineBus LineBusDOBOAdapter(DalApi.DO.Line line,IEnumerable<DalApi.DO.LineStation> stations);
        void AddStationToLine(int LineCode, int StationCode);
        IEnumerable<LineBus> GetsAllLines();
        IEnumerable<LineBus> GetSpecificLines(Predicate<DalApi.DO.LineStation> predicate);
        IEnumerable<LineBus> GetBusFromArea(DalApi.DO.Areas Area);
        LineBus GetLine();
        void DeleteLine(int LineCode);
        #endregion
        #region Stations
        #endregion

    }
}
