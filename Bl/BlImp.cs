using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using Bl.BO;
using DalApi.DO;

namespace Bl
{
    class BlImp:IBl
    {
        IDal Dl = DalFactory.GetDL();
        #region LineBus
        public void AddStationToLine(int LineCode, int StationCode)
        {
            DalApi.DO.Station station;
            try
            {
                station = Dl.GetStation(StationCode);
            }
            catch(Exception ex)
            {
                
            }
            DalApi.DO.Line line;
            try
            {
                line = Dl.GetLine(LineCode);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void DeleteLine(int LineCode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineBus> GetBusFromArea(Areas Area)
        {
            throw new NotImplementedException();
        }

        public LineBus GetLine()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineBus> GetsAllLines()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineBus> GetSpecificLines(Predicate<DalApi.DO.LineStation> predicate)
        {
            throw new NotImplementedException();
        }

        public LineBus LineBusDOBOAdapter(Line line, IEnumerable<DalApi.DO.LineStation> stations)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
