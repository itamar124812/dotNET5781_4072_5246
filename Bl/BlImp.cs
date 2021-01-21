using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using Bl.BO;
using DalApi.DO;
using BlApi;

namespace Bl
{
    class BlImp:IBl
    {
        #region Singalton
        IDal Dl = DalFactory.GetDL();
        static readonly BlImp instance = new BlImp();
        static BlImp() { }
        BlImp() { }
        public static BlImp Instance { get => instance; }
        #endregion
        #region LineBus
        public void UpdateLineCode(int ID,int NewCode)
        {
            try
            {
                Dl.UpdateCode(ID, NewCode);
            }
            catch (DalApi.DO.LineException ex)
            {

                throw new BadLineExceptions(string.Format("The Line {0} does not exists",ID), ex);
            }        
        }
        public IEnumerable<Bl.BO.LineStation> GetStationsInLine(int Id)
        {

            IEnumerable<DalApi.DO.LineStation> Stations = Dl.GetsAllStationInLine(Id);
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
        public void AddLine(int CodeLine, int area, int LastStation)
        {
            DalApi.DO.Line line = new DalApi.DO.Line();
            if (area > 4 || area < 0)
                throw new ArgumentException("There is only five areas: North, South, Central, Jerusalem, General.");
            line.Code = CodeLine;
            line.Area = (DalApi.DO.Areas)area;
            try
            {
                if (Dl.GetStation(LastStation) != null)
                    line.LastStation = LastStation;
            }
            catch (DalApi.DO.StationException ex)
            {
                Random random = new Random();
                DalApi.DO.Station station = new Station();
                station.Code = LastStation;
                station.Name = "LastStation";
                station.Latitude=random.NextDouble() * 2.1 + 31;
                station.Longitude = random.NextDouble() * 1.2 + 34.3;
                Dl.AddStation(station);
            }
            try
            {
                Dl.AddLine(line);
            }
            catch (DalApi.DO.LineException ex)
            {
                throw new Bl.BO.BadLineExceptions("The line already exits.", ex);
            }
            AddStationToLine(line.Id, LastStation, 0,0,TimeSpan.Parse("00:00:00"));
        }

        public void AddStationToLine(int Id, int StationNum,int index, double distanceFromLastStation, TimeSpan timeFromLastStation)
        {
            if (index >= 0)
            {               
                DalApi.DO.LineStation linestation = new DalApi.DO.LineStation();
                List<Bl.BO.LineStation> Stations = GetStationsInLine(Id).ToList();
                try
                {
                    Line line = Dl.GetLine(Id);
                    if ( line != null && Dl.GetStation(StationNum) != null)
                    {
                        linestation.LineId = Id;
                        linestation.LineStationIndex = index;
                        linestation.Station = StationNum;
                        List<DalApi.DO.LineStation> lineStations = Dl.GetsAllStationInLine(Id).ToList();
                        if (index > 0 && index < lineStations.Count)
                        {
                            linestation.PrevStation = lineStations[index - 1].Station;
                            //AdjacentStations adjacentStations = new AdjacentStations();
                            //adjacentStations.Station1 = lineStations[index - 1].Station;
                            //adjacentStations.Station2 = linestation.Station;
                            //adjacentStations.Distance = distanceFromLastStation;
                            //adjacentStations.Time = timeFromLastStation;
                            //Dl.AddAdjacentStations(adjacentStations);
                        }
                        if (index >= 0 && index < lineStations.Count-1)
                        {
                            linestation.NextStation = lineStations[index + 1].Station;
                            //AdjacentStations adjacentStations = new AdjacentStations();
                            //adjacentStations.Station1 = lineStations[index + 1].Station;
                            //adjacentStations.Station2 = linestation.Station;
                            //adjacentStations.Distance = distanceFromLastStation;
                            //adjacentStations.Time = timeFromLastStation;
                            //Dl.AddAdjacentStations(adjacentStations);
                        }
                            GetLine(Id).PassingThrough = GetStationsInLine(StationNum);
                    }
                }
                catch (DalApi.DO.LineException ex)
                {

                    throw new BadLineExceptions("The Line does not exists", ex);
                }
                catch (DalApi.DO.StationException ex)
                {

                    throw new BadStationException("The Station does not exists ",ex);
                }

                if (index < Stations.Count)
                {
                    List<DalApi.DO.LineStation> stations = Dl.GetsAllStationInLine(Id).ToList();
                    foreach (var item in stations)
                    {
                        Dl.Update(item, true);
                        GetLine(Id).PassingThrough = GetStationsInLine(StationNum);
                    }
                }
                
                Dl.AddLineStation(linestation);
            }
            else throw new IndexOutOfRangeException();
        }

        public void DeleteLine(int Id)
        {
            try
            {
                foreach (var item in GetStationsInLine(Id))
                {
                    Dl.DeleteLineStation(Id, item.Code);
                }
                Dl.DeleteLine(Id);
            }
            catch (DalApi.DO.LineException ex)
            {
                throw new BadLineExceptions(string.Format("The line with the ID number {0} does not exist.",Id), ex);
            }
           
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
                line.Id = item.Id;
                line.PassingThrough = GetStationsInLine(line.Id);            
                Lines.Add(line);
            }
            return from line in Lines
                   select line;
        }
        
        public LineBus GetLine(int ID)
        {
            LineBus ReturnedLineBus = new LineBus();
            DalApi.DO.Line line = new Line();
            try
            {
                line = Dl.GetLine(ID);
            }
            catch (DalApi.DO.LineException ex)
            {
                throw new Bl.BO.BadLineExceptions("The line isn't exits", ex);
            }
            ReturnedLineBus.Id = line.Id;
            ReturnedLineBus.Code = line.Code;
            ReturnedLineBus.Area = (int) line.Area;
            ReturnedLineBus.PassingThrough = GetStationsInLine(ID);
            return ReturnedLineBus;
        }

        public IEnumerable<LineBus> GetsAllLines()
        {
            List<DalApi.DO.Line> Lines =Dl.GetAllLines().ToList();
            List<Bl.BO.LineBus> lines = new List<Bl.BO.LineBus>();
            foreach (var item in Lines)
            {
                lines.Add(GetLine(item.Id));
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
                    List<StationLine> AllLines = new List<StationLine>();
                    foreach (var item in lines)
                    {
                        StationLine line = new StationLine();
                        line.IDLine = item.Id;
                        line.LineNumber = item.Code;
                        line.LastStop = item.PassingThrough.Last().Name;
                        line.Arrivaltimes = TimeUntilStation(item, StationCode);
                        AllLines.Add(line);
                    }
                    result.LinesPassingThrough = AllLines;
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
       public  IEnumerable<BusStation> GetAllStations()
        {
            List<DalApi.DO.Station>Lines = Dl.GetAllStations().ToList();
            return from station in Lines
                   select GetAllLinesForStation(station.Code);
        }
        #endregion
        #region Users
       public void AddUser(string name, string password, bool Admin) 
        {
            DalApi.DO.User NewUser = new DalApi.DO.User();
            NewUser.UserName = name;
            NewUser.Password = password;
            NewUser.Adnmin = Admin;
            try
            {
                Dl.AddUser(NewUser);
            }
            catch (DalApi.DO.UserExceptions ex)
            {
                throw new UserException(string.Format("The name {0} is already taken. Choose another name:", name), ex);
            }
           
        }
        public bool IsAdmin(string UserName)
        {
            try
            {
                DalApi.DO.User user = Dl.GetUser(UserName);
                if (user.Adnmin)
                    return true;
            }
            catch (DalApi.DO.UserExceptions ex)
            {
                throw new UserException(string.Format("There is no user named {0}.",UserName), ex);
            }
            return false;
        }
        public void DeleteUser(string name) 
        {
            try
            {
                Dl.DeleteUser(name);
            }
            catch (DalApi.DO.UserExceptions ex)
            {

                throw new UserException(string.Format("There is no user named {0}.", name), ex);
            }
        }
        public bool IsExists(string UserName)
        {
            try
            {
                if (Dl.GetUser(UserName) != null)
                    return true;
            }
            catch (DalApi.DO.UserExceptions)
            {
              
            }
            return false;
        }
        public bool CheckPassword(string UserName,string password)
        {
            if (IsExists(UserName))
            {
                DalApi.DO.User user = Dl.GetUser(UserName);
                if (user.Password == password)
                    return true;
                return false;
            }
            throw new UserException((string.Format("There is no user named {0}.", UserName)));


        }
        #endregion
        #region LineTrips
        public void AddLineTrip(int Id,TimeSpan StartTime)
        {
            DalApi.DO.LineTrip trip = new LineTrip();
            trip.LindId = Id;
            trip.StartAt = StartTime;
            try
            {
                Dl.AddLineTrip(trip);
            }
            catch (DalApi.DO.LineTripException ex)
            {
                throw new LineTripsException(string.Format("There is already a line trip with a similar Id: {0} who StartAt: {1}.",Id,StartTime), ex);
            }           
        }
        public void DeleteLineTrip(int Id,TimeSpan StartAt)
        {
            try
            {
                Dl.DeleteLineTrip(Id, StartAt);
            }
            catch (DalApi.DO.LineTripException ex)
            {
                throw new LineTripsException(string.Format("There is not line trip with a similar Id: {0} who StartAt: {1}.", Id, StartAt), ex);
            }
        }
        public void UpdateStartTime(int Id,TimeSpan key,TimeSpan time)
        {
            try
            {
                Dl.UpdateStartTime(Id, key,time);
            }
            catch (DalApi.DO.LineTripException ex)
            {
                throw new LineTripsException(string.Format("There is already a line trip with a similar Id: {0} who StartAt: {1}.", Id, time), ex);
            }          
        }
        #endregion
    }
}



