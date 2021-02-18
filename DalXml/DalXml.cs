using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DalApi;
using System.IO;
using DalApi.DO;

namespace DalXml
{
    class DalXml : IDal
    {
        #region singelton
        static readonly DalXml instance = new DalXml();
        static DalXml() { }// static ctor to ensure instance init is done just before first usage
        DalXml() { } // default => private
        public static DalXml Instance { get => instance; }// The public Instance property to use
        #endregion
        #region DS XML Files
        string StationPath =  @".\StopsAfterChange.xml";
        string LinesPath = @".\Lines.xml";
        string LineStationPath = @".\LineStation.xml";
        string LinesTripPath = @".\LinesTrip.xml";
        string UsersPath = @".\Users.xml";
        string AdjacentStationsPath = @".\AdjacentStations.xml";
        //XmlElement
        string BusPath = @".\Bus.xml";
        #endregion
        #region AdjacentStations
        public void AddAdjacentStations(AdjacentStations adjacentStations)
        {
            List<AdjacentStations> listAS = XMLTools.LoadListFromXMLSerializer<AdjacentStations>(AdjacentStationsPath);
            if (listAS.Find(a => a.Station1 == adjacentStations.Station1&& a.Station2==adjacentStations.Station2 ) != null) throw new DalApi.DO.AdjacentStationsException(adjacentStations.Station1,adjacentStations.Station2, "Duplicate AdjacentStations");
            listAS.Add(adjacentStations);
            XMLTools.SaveListToXMLSerializer<AdjacentStations>(listAS, AdjacentStationsPath);        
        }
        public void DeleteAdjacentStations(Station A, Station B)
        {
            List<AdjacentStations> listAS = XMLTools.LoadListFromXMLSerializer<AdjacentStations>(AdjacentStationsPath);
            AdjacentStations As = listAS.Find(a => a.Station1 == A.Code && a.Station2 == B.Code);
            if (As == null) throw new AdjacentStationsException(A.Code, B.Code, "This station does not exsits.");
            listAS.Remove(As);
            XMLTools.SaveListToXMLSerializer<AdjacentStations>(listAS, AdjacentStationsPath);
        }
        public AdjacentStations GetAdjacentStations(Station A, Station B)
        {
            List<AdjacentStations> listAS = XMLTools.LoadListFromXMLSerializer<AdjacentStations>(AdjacentStationsPath);
            AdjacentStations As = listAS.Find(a => a.Station1 == A.Code && a.Station2 == B.Code);
            if (As == null) throw new AdjacentStationsException(A.Code, B.Code, "This station does not exsits.");
            return As;           
        }
        public IEnumerable<AdjacentStations> GetALLAdjacentStations()
        {
            List<AdjacentStations> listAS = XMLTools.LoadListFromXMLSerializer<AdjacentStations>(AdjacentStationsPath);
            return from Astation in listAS
                   select Astation;           
        }
        #endregion
        #region Buses
        public Bus GetBus(int LicenseNum)
        {
            XElement BusesList = XMLTools.LoadListFromXMLElement(BusPath);
            XElement Busi = (from Bus in BusesList.Elements()
                             where int.Parse(Bus.Element("LicenseNum").Value) == LicenseNum
                             select Bus).FirstOrDefault();
            if (Busi == null)
                throw new DalApi.DO.BadBusException(LicenseNum, "This bus does not exists.");
            return new Bus() { FromDate = DateTime.Parse(Busi.Element("FromDate").Value),LicenseNum=int.Parse(Busi.Element("LicenseNumber").Value), FuelRemain=double.Parse(Busi.Element("FuelRemain").Value), Status =(BusStatus)int.Parse( Busi.Element("Status").Value), TotalTrip=double.Parse(Busi.Element("TotalTrip").Value) };
        }
        public void AddBus(Bus bus)
        {
            XElement BusesList = XMLTools.LoadListFromXMLElement(BusPath);
            XElement Busi = (from Bus in BusesList.Elements()
                           where int.Parse(Bus.Element("LicenseNum").Value) == bus.LicenseNum 
                           select Bus).FirstOrDefault();
            if (Busi != null)
                throw new DalApi.DO.BadBusException(bus.LicenseNum,"Dolpicate bus");
            XElement AddBusElement = new XElement("Bus", new XElement("LicenseNumber", bus.LicenseNum),
                new XElement("FromDate", bus.FromDate), new XElement("FuelRemain", bus.FuelRemain), new XElement("TotalTrip", bus.TotalTrip),new XElement("Status",(int) bus.Status));
            BusesList.Add(AddBusElement);
            XMLTools.SaveListToXMLElement(BusesList, BusPath);
        }
        public void DeleteBus(int LicenseNum)
        {
            XElement BusesList = XMLTools.LoadListFromXMLElement(BusPath);
            XElement Busi = (from Bus in BusesList.Elements()
                             where int.Parse(Bus.Element("LicenseNumber").Value) == LicenseNum
                             select Bus).FirstOrDefault();
            if (Busi == null)
                throw new DalApi.DO.BadBusException(LicenseNum, "Dolpicate bus");
            Busi.Remove();
            XMLTools.SaveListToXMLElement(BusesList, BusPath);
        }
        public IEnumerable<Bus> GetAllBuses()
        {
            XElement BusesList = XMLTools.LoadListFromXMLElement(BusPath);
            return from bus in BusesList.Elements()
            select (GetBus(int.Parse(bus.Element("LicenseNumber").Value)));
        }
        #endregion 
        #region BusOnTrip
        public void AddBusOnTrip(BusOnTrip Trip)
        {
            throw new NotImplementedException();
        }
        public void DeleteBusOnTrip(int Id)
        {
            throw new NotImplementedException();
        }
        public BusOnTrip GetBusOnTrip(int Id)
        {
            throw new NotImplementedException();
        }
        #endregion 
        #region Lines
        public void UpdateCode(int id, int newcode)
        {
            List<Line> Lines = XMLTools.LoadListFromXMLSerializer<Line>(LinesPath);
            Line line = Lines.Find(L => L.Id == id);
            if (line != null)
            {
                Lines.Remove(line);
                line.Code = newcode;
                Lines.Add(line);
                XMLTools.SaveListToXMLSerializer<Line>(Lines, LinesPath);
            }
            else throw new LineException(id, newcode, "The Line does not exists");
        }
        public void AddLine(Line line)
        {
            List<Line> Lines = XMLTools.LoadListFromXMLSerializer<Line>(LinesPath).OrderBy(l => l.Id).ToList();
            if (Lines.Count > 0)
            { Line.RunningNum = Lines[Lines.Count - 1].Id; }
            else Line.RunningNum = 0;
            line.Id = ++Line.RunningNum;
            Lines.Add(line);
            XMLTools.SaveListToXMLSerializer<Line>(Lines, LinesPath);
        }
        public void DeleteLine(int id)
        {
            List<Line> Lines = XMLTools.LoadListFromXMLSerializer<Line>(LinesPath);
            Line line = Lines.Find(L => L.Id == id);
            if (line != null)
            {
                Lines.Remove(line);
                XMLTools.SaveListToXMLSerializer<Line>(Lines, LinesPath);
            }
            else throw new LineException(id, 0 , "The Line does not exists.");
        }
        public IEnumerable<Line> GetAllLines()
        {
            List<Line> Lines = XMLTools.LoadListFromXMLSerializer<Line>(LinesPath);
            return from line in Lines
                   select line;
        }
        public Line GetLine(int id)
        {
            List<Line> Lines = XMLTools.LoadListFromXMLSerializer<Line>(LinesPath);
            Line line = Lines.Find(L => L.Id == id);
            if (line != null)
            {
                return line;
            }
            else throw new LineException(id, 0, "The Line does not exists.");
        }

        #endregion
        #region LineStation
        public void AddLineStation(LineStation lineStation)
        {
            List<LineStation> LineStations = XMLTools.LoadListFromXMLSerializer<LineStation>(LineStationPath);
            if (LineStations.Find(LS => LS.LineId == lineStation.LineId && LS.Station == lineStation.Station) != null)
                throw new LineStationException(lineStation.LineId, lineStation.Station, "Duplicate Line Station");
            LineStations.Add(lineStation);
            XMLTools.SaveListToXMLSerializer<LineStation>(LineStations, LineStationPath);
        }
        public void DeleteLineStation(int LineNum, int StationNum)
        {
            List<LineStation> LineStations = XMLTools.LoadListFromXMLSerializer<LineStation>(LineStationPath);
            LineStation lineStation=  LineStations.Find(LS => LS.LineId == LineNum && LS.Station == StationNum);
            if (lineStation == null) { throw new LineStationException(LineNum, lineStation.Station, "The Line Station does not exsits"); }
            LineStations.Remove(lineStation);
            XMLTools.SaveListToXMLSerializer<LineStation>(LineStations, LineStationPath);
        }
        public LineStation GetLineStation(int LineNum, int StationNum)
        {
            List<LineStation> LineStations = XMLTools.LoadListFromXMLSerializer<LineStation>(LineStationPath);
            LineStation lineStation = LineStations.Find(LS => LS.LineId == LineNum && LS.Station == StationNum);
            if (lineStation == null) { throw new LineStationException(LineNum, lineStation.Station, "The Line Station does not exsits"); }
            return lineStation;
        }
        public IEnumerable<LineStation> GetsAllStationInLine(int LineNum)
        {
            List<LineStation> LineStations = XMLTools.LoadListFromXMLSerializer<LineStation>(LineStationPath);
            return from ls in LineStations
                   where ls.LineId == LineNum
                   select ls;
        }
        public void Update(LineStation station, bool PlusOrMinus)
        {
            if (PlusOrMinus)
                station.LineStationIndex++;
            else station.LineStationIndex--;
        }
        #endregion
        #region LineTrip
        public IEnumerable<LineTrip> GetAllLineTrips()
        {
            List<LineTrip> lineTrips = XMLTools.LoadListFromXMLSerializer<LineTrip>(LinesTripPath);
            return from Lt in lineTrips
                   select Lt;
        }
        public void UpdateStartTime(int Id, TimeSpan key, TimeSpan time)
        {
            List<LineTrip> lineTrips = XMLTools.LoadListFromXMLSerializer<LineTrip>(LinesTripPath);
            LineTrip lineTrip = lineTrips.Find(l => l.LindId == Id && l.StartAt==key);
            if (lineTrip == null) throw new LineTripException(Id, time, "The Line trip does not exists");
            lineTrips.Remove(lineTrip);
            lineTrip.StartAt = time;
            lineTrips.Add(lineTrip);
            XMLTools.SaveListToXMLSerializer<LineTrip>(lineTrips, LinesTripPath);
        }
        public LineTrip GetLineTrip(int LineNumber, TimeSpan startAt)
        {
            List<LineTrip> lineTrips = XMLTools.LoadListFromXMLSerializer<LineTrip>(LinesTripPath);
            LineTrip lineTrip = lineTrips.Find(l => l.LindId == LineNumber && l.StartAt==startAt);
            if (lineTrip == null) throw new LineTripException(LineNumber, startAt, "The Line trip does not exists");
            return lineTrip;
        }
        public IEnumerable<LineTrip> GetsAllTripsForLine(int LineNumber)
        {
            List<LineTrip> lineTrips = XMLTools.LoadListFromXMLSerializer<LineTrip>(LinesTripPath);
            return from lt in lineTrips
                   select lt;
        }
        public void AddLineTrip(LineTrip lineTrip)
        {
            List<LineTrip> lineTrips = XMLTools.LoadListFromXMLSerializer<LineTrip>(LinesTripPath);
            if (lineTrips.Find(l => l.LindId == lineTrip.LindId && l.StartAt == lineTrip.StartAt) != null) throw new LineTripException(lineTrip.LindId, lineTrip.StartAt, "Duplicate Line Trip");
            lineTrips.Add(lineTrip);
            XMLTools.SaveListToXMLSerializer<LineTrip>(lineTrips, LinesTripPath);
        }
        public void DeleteLineTrip(int LineNumber, TimeSpan startAt)
        {
            List<LineTrip> lineTrips = XMLTools.LoadListFromXMLSerializer<LineTrip>(LinesTripPath);
            LineTrip lineTrip = lineTrips.Find(l => l.LindId == LineNumber && l.StartAt == startAt);
            if (lineTrip == null) throw new LineTripException(LineNumber, startAt, "The Line trip does not exists");
            lineTrips.Remove(lineTrip);
            XMLTools.SaveListToXMLSerializer<LineTrip>(lineTrips, LinesTripPath);
        }
        #endregion
        #region Stations
        public void AddStation(Station station)
        {
            List<Station> stations = XMLTools.LoadListFromXMLSerializer<Station>(StationPath);
            if (stations.Find(s => s.Code == station.Code) != null) throw new StationException(station.Code, "Duplicate Station");
            stations.Add(station);
            XMLTools.SaveListToXMLSerializer<Station>(stations, StationPath);
        }
        public void DeleteStation(int code)
        {
            List<Station> stations = XMLTools.LoadListFromXMLSerializer<Station>(StationPath);
            Station station = stations.Find(s => s.Code == code);
            if (station == null) throw new StationException(code, "The station does not exists");
            stations.Remove(station);
            XMLTools.SaveListToXMLSerializer<Station>(stations, StationPath);
        }
        public IEnumerable<Station> GetAllStations()
        {
            List<Station> stations = XMLTools.LoadListFromXMLSerializer<Station>(StationPath);
            return from station in stations
                   select station;
        }
        public Station GetStation(int code)
        {
            List<Station> stations = XMLTools.LoadListFromXMLSerializer<Station>(StationPath);
            Station station = stations.Find(s => s.Code == code);
            if (station == null) throw new StationException(code, "The station does not exists");
            return station;
        }
        #endregion       
        #region Users
        public void AddUser(User user)
        {
            List<User> users = XMLTools.LoadListFromXMLSerializer<User>(UsersPath);
            if (users.Find(u => u.UserName == user.UserName) != null)
                throw new UserExceptions(user.UserName, "Duplicate User");
            users.Add(user);
            XMLTools.SaveListToXMLSerializer<User>(users, UsersPath);
        }
        public void DeleteUser(string user)
        {
            List<User> users = XMLTools.LoadListFromXMLSerializer<User>(UsersPath);
            User RemovedUser = users.Find(u => u.UserName == user);
            if (RemovedUser == null) throw new UserExceptions(user, "The User does not exists");
            users.Remove(RemovedUser);
            XMLTools.SaveListToXMLSerializer<User>(users, UsersPath);
        }
        public IEnumerable<User> GetAllUsers()
        {
            List<User> users = XMLTools.LoadListFromXMLSerializer<User>(UsersPath);
            return from user in users
                   select user;
        }
        public User GetUser(string Name)
        {
            List<User> users = XMLTools.LoadListFromXMLSerializer<User>(UsersPath);
            User ReturnedUser = users.Find(u => u.UserName == Name);
            if (ReturnedUser == null) throw new UserExceptions(Name, "The User does not exists");
            return ReturnedUser;
        }
        #endregion
        #region Trips
        public void AddTrip(Trip trip)
        {
            throw new NotImplementedException();
        }
        public void DeleteTrip(int Id)
        {
            throw new NotImplementedException();
        }
        public Trip GetTrip(int ID)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
