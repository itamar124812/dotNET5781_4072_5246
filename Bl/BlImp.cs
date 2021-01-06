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

        public void AddStation(double latitude, double longitude, int codeStation, string name)
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

        public void DeleteStations(int StationCode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineBus> GetBusFromArea(int Area)
        {
            IEnumerable<DalApi.DO.Line> lines = Dl.GetAllLines();
            IEnumerable<DalApi.DO.Line> Selectedlines = from line in lines
            where line.Area == (DalApi.DO.Areas)Area
            select line;
            List<LineBus> Lines = new List<LineBus>();
            foreach (var item in Selectedlines)
            {
                LineBus line = new LineBus();
                line.Code = item.Code;
                line.Area =(int) item.Area;
                line.PassingThrough=
                Lines.Add(line);
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
