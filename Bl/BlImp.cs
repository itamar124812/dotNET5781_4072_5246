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
        IEnumerable<Bl.BO.LineStation> GetStationsInLine(int Id,int lineCode)
        {

           IEnumerable<DalApi.DO.LineStation> Stations= Dl.GetsAllStationInLine(lineCode);
            List<Bl.BO.LineStation> result = new List<BO.LineStation>();
            DalApi.DO.Station LastStation = new Station();
            foreach (var item in Stations)
            {
                BO.LineStation lineStation = new BO.LineStation();
                DalApi.DO.Station RealStation = Dl.GetStation(item.Station);
                lineStation.Code = item.Station;
                lineStation.Name = RealStation.Name;
                if (LastStation.Equals(null))
                {
                    DalApi.DO.AdjacentStations AS = Dl.GetAdjacentStations(LastStation, RealStation);
                    lineStation.DistanceFromLastStation = AS.Distance;
                    lineStation.TimeFromLastStation = AS.Time;                   
                }
                result.Add(lineStation);
                LastStation = Dl.GetStation(item.Station);
            }
            return from line in result
            select line;
        }
        public void AddLine(int CodeLine,int area,int LastStation)
        {
            DalApi.DO.Line line = new DalApi.DO.Line();
            line.Code = CodeLine;
            line.Area = (DalApi.DO.Areas)area;
            try
            {
                if (Dl.GetStation(LastStation) != null)
                    line.LastStation = LastStation;
            }
            catch (DalApi.DO.StationException ex)
            {
                throw new Bl.BO.BadStationException("This Station isn't exits.", ex);
            }
            try
            {
                Dl.AddLine(line);
            }
            catch (DalApi.DO.LineException ex)
            {
                throw new  Bl.BO.BadLineExceptions("The line already exits.", ex);
            }
            AddStationToLine(line.Id,line.Code, LastStation, 0);
        }

     
        #region LineBus
        public void AddStationToLine(int Id,int LineCode, int StationNum,int index)
        {
            if (index <= 0)
            { 
                DalApi.DO.LineStation linestation = new DalApi.DO.LineStation();
                List<Bl.BO.LineStation> Stations = GetStationsInLine(Id,LineCode).ToList();
                try
                {
                    if (Dl.GetLine(Id,LineCode) != null && Dl.GetStation(StationNum) != null)
                    {
                        linestation.Lineld = LineCode;
                        linestation.LineStationIndex = index;
                        linestation.Station = StationNum;
                    }
                }
                catch (DalApi.DO.LineException ex)
                {

                    throw new BadLineExceptions("The Line does not exists", ex);
                }
                catch (DalApi.DO.StationException ex)
                {

                    throw new BadStationException("The Line does not exists ",ex);
                }

                if (index < Stations.Count)
                {
                    List<DalApi.DO.LineStation> stations = Dl.GetsAllStationInLine(LineCode).ToList();
                    foreach (var item in stations)
                    {
                        Dl.Update(item, true);
                    }
                }
                
                Dl.AddLineStation(linestation);
            }
            else throw new IndexOutOfRangeException();
        }

        public void DeleteLine(int Id,int LineCode)
        {
            foreach (var item in GetStationsInLine(Id,LineCode))
            {
                Dl.DeleteLineStation(LineCode, item.Code);
            }
            Dl.DeleteLine(LineCode);
        }


        public IEnumerable<LineBus> GetBusFromArea(int Area)
        {
            IEnumerable<DalApi.DO.Line> lines = Dl.GetAllLines();
            IEnumerable<DalApi.DO.Line> Selectedlines = from line in lines
            where line.Area == (DalApi.DO.Areas)Area
            select line;
            List<Bl.BO.LineBus> Lines = new List<LineBus>();
            foreach (var item in Selectedlines)
            {
                LineBus line = new LineBus();
                line.Code = item.Code;
                line.Area =(int) item.Area;
                line.PassingThrough = GetStationsInLine(line.Id,line.Code);
                Lines.Add(line);
            }
            return from line in Lines
                   select line;
        }
        
        public LineBus GetLine(int ID,int LineCode)
        {
            LineBus ReturnedLineBus = new LineBus();
            DalApi.DO.Line line = new Line();
            try
            {
                line = Dl.GetLine(ID,LineCode);
            }
            catch (DalApi.DO.LineException ex)
            {
                throw new Bl.BO.BadLineExceptions("The line isn't exits", ex);
            }
            ReturnedLineBus.Code = line.Code;
            ReturnedLineBus.Area = (int) line.Area;
            ReturnedLineBus.PassingThrough = GetStationsInLine(ID,LineCode);
            return ReturnedLineBus;
        }

        public IEnumerable<LineBus> GetsAllLines()
        {
            List<DalApi.DO.Line> Lines =Dl.GetAllLines().ToList();
            List<Bl.BO.LineBus> lines = new List<Bl.BO.LineBus>();
            foreach (var item in Lines)
            {
                lines.Add(GetLine(item.Id,item.Code));
            }
            return from line in lines
                   orderby line.Code
                   select line;
        }

        public IEnumerable<LineBus> GetSpecificLines(Predicate<LineBus> predicate)
        {
            return from line in GetsAllLines()
                   where predicate(line)
                   select line;
        }

        public LineBus LineBusDOBOAdapter(Line line, IEnumerable<DalApi.DO.LineStation> stations)
        {
            throw new NotImplementedException();
        }
        





        #endregion
















        #region Stations
        public void DeleteStations(int StationCode)
        {
            Dl.DeleteStation(StationCode);
        }
        public void ADDStation(double latitude, double longitude, int codeStation, String name)
        {
            Station a = new Station();
            a.Code = codeStation;
            a.Latitude = latitude;
            a.Longitude = longitude;
            a.Name = name;
            Dl.AddStation(a);
        }
       public BusStation GetAllLinesForStation(int StationCode)
        {
            BusStation result = new BusStation();
            try
            {
                if (Dl.GetStation(StationCode) != null)
                {
                    result.StationNumber = StationCode;
                    List<LineBus> lines = GetsAllLines().Where(L => LinePassStation(StationCode, L)).ToList();
                    foreach (var item in lines)
                    {
                        StationLine line = new StationLine();
                        line.IDLine = item.Id;
                        line.LineNumber = item.Code;
                        line.LastStop = item.PassingThrough.Last().Name;
                        line.Arrivaltimes = TimeUntilStation(item, StationCode);
                    }
                }
            }
            catch (DalApi.DO.StationException ex)
            {
                throw new BadStationException("The Station does not exits.", ex);  
            }

           
            return result;
        }
       private bool LinePassStation(int station,LineBus line)
        {
            foreach (var item in line.PassingThrough)
            {
                if (item.Code == station) return true;
            }
            return false;
        }
        private TimeSpan TimeUntilStation(LineBus line,int station)
        {
            TimeSpan result = new TimeSpan();
            foreach (var item in line.PassingThrough)
            {
                if (item.Code == station) continue;
                result += item.TimeFromLastStation;
            }
            return result;

        }
        #endregion

    }
}



