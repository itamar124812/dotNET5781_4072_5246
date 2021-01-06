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

        public void AddLine(int CodeLine)
        {
            throw new NotImplementedException();
        }
        #region LineBus
        public void AddStationToLine(int LineCode, int StationNum,int index)
        {
            
        

        }

        public void DeleteLine(int LineCode)
        {
            
            Dl.DeleteLine(LineCode);
        }

        public IEnumerable<LineBus> GetBusFromArea(Areas Area)
        {
            IEnumerable<DalApi.DO.Line> lines = Dl.GetAllLines();
            IEnumerable<DalApi.DO.Line> Selectedlines = from line in lines
            where line.Area == Area
            select line;
            foreach (var item in Selectedlines)
            {

            }
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
