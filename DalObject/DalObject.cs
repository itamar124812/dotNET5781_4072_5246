using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DalApi.DO;
using DS;


namespace DalObject
{
    class DalObject : IDal
    {
        #region Singelton
        static readonly DalObject instance = new DalObject();
        static DalObject() { }
        DalObject() { } 
        public static DalObject Instance { get => instance; }
        #endregion
        #region Bus
        public void AddBus(DalApi.DO.Bus bus)
        {
            if (DS.DataSource.ListBuses.Find(b => b.LicenseNum == bus.LicenseNum) != null)
            {
                throw new DalApi.DO.BadBusException(bus.LicenseNum, "There is already a bus with the same license number:");
            }
            DataSource.ListBuses.Add(bus.Clone());
        }
        public void DeleteBus(int LicenseNum)
        {
            DalApi.DO.Bus RemuveBus = DS.DataSource.ListBuses.Find(b => b.LicenseNum == LicenseNum);
            if (RemuveBus != null)
            {
                DS.DataSource.ListBuses.Remove(RemuveBus);
            }
            else throw new DalApi.DO.BadBusException(LicenseNum, "The bus does not exist . license number:");
        }
        public IEnumerable<Bus> GetAllBuses()
        {
            return from  bus in DS.DataSource.ListBuses
                   select bus.Clone();
         }
        public Bus GetBus(int LisenceNum)
        {
          DalApi.DO.Bus bus =  DataSource.ListBuses.Find(b => b.LicenseNum == LisenceNum);
            if (bus != null)
                return bus.Clone();
            else throw new DalApi.DO.BadBusException(LisenceNum, "The bus does not exist . license number:");
        }
        #endregion
        #region BusOnTrip
        public void AddBusOnTrip(DalApi.DO.BusOnTrip trip)
        {
            if(DS.DataSource.ListBusOnTrips.Find(BOT=>BOT.RunningNum ==trip.RunningNum)!=null)
            {
                throw new DalApi.DO.BadBusOnTripException(trip.RunningNum, "Duplicate BusOnTrip Id:");
            }
            DS.DataSource.ListBusOnTrips.Add(trip.Clone());
        }
        public void DeleteBusOnTrip(int Id)
        {
            DalApi.DO.BusOnTrip busOnTrip = DataSource.ListBusOnTrips.Find(BOT => BOT.RunningNum == Id);
            if (busOnTrip != null)
                DataSource.ListBusOnTrips.Remove(busOnTrip);
            else throw new DalApi.DO.BadBusOnTripException(Id, "There is no bus Trip with such an identification number:");
                
        }
        public BusOnTrip GetBusOnTrip(int Id)
        {
            DalApi.DO.BusOnTrip busOnTrip= DataSource.ListBusOnTrips.Find(BOT => BOT.RunningNum == Id);
            if (busOnTrip != null)
                return busOnTrip.Clone();
            else throw new DalApi.DO.BadBusOnTripException(Id, "There is no bus Trip with such an identification number:");
        }
        #endregion
        #region Station
        public IEnumerable<Station> GetAllStations()
        {
            return from station in DataSource.ListStations
                   orderby station.Code
                   select station.Clone();

        } 
        public void AddStation(DalApi.DO.Station station)
        {
            if (DataSource.ListStations.Find(s => s.Code == station.Code) != null)
            {
                throw new DalApi.DO.StationException(station.Code, "Duplicate Station code.");
            }
            else DataSource.ListStations.Add(station.Clone());

        }
        public void DeleteStation(int code)
        {
            Station station = DataSource.ListStations.Find(S => S.Code == code);
            if (station == null) throw new DalApi.DO.StationException(code, "There is no such station.");
            DataSource.ListStations.Remove(station);
        }
        public Station GetStation(int code)
        {
            Station Result = DataSource.ListStations.Find(S => S.Code == code);
            if(Result!=null) return Result.Clone();
            throw new DalApi.DO.StationException(code, "There is no such station.");
        }
        #endregion
        #region User
        public void AddUser(DalApi.DO.User user)
        {
           if(DataSource.UsersManager.Find(User=>user.UserName==User.UserName)!=null)
            {
                throw new DalApi.DO.UserExceptions(user.UserName, "Duplicate User UserName:");
            }
            DataSource.UsersManager.Add(user);
        }
        public void DeleteUser(string userName)
        {
            DalApi.DO.User user = DataSource.UsersManager.Find(U => U.UserName == userName);
            if (user == null) throw new DalApi.DO.UserExceptions(userName, "The badUser:");
            else DataSource.UsersManager.Remove(user.Clone());
        }
        public IEnumerable<User> GetAllUsers()
        {
          return  from  user in DataSource.UsersManager
            select user.Clone();
        }
        public User GetUser(string userName)
        {
            DalApi.DO.User result = DataSource.UsersManager.Find(U => U.UserName == userName);
            if (result == null) throw new DalApi.DO.UserExceptions(userName, "The badUser:");
            else return result.Clone();
        }
        #endregion
#region Trip
        public void AddTrip(DalApi.DO.Trip trip)
        {
            if (DataSource.ListTrip.Find(T => T.Id == trip.Id) != null)
                throw new DalApi.DO.TripException(trip.Id, "Duplicate Trip id.");
            DataSource.ListTrip.Add(trip.Clone());
        }
        public void DeleteTrip(int code)
        {
            DalApi.DO.Trip trip = DataSource.ListTrip.Find(T => T.Id == code);
            if (trip != null)
                throw new DalApi.DO.TripException(code, "There is no such trip.");
            DataSource.ListTrip.Remove(trip.Clone());
        }
        public Trip GetTrip(int ID)
        {
            DalApi.DO.Trip trip = DataSource.ListTrip.Find(T => T.Id == ID);
            if (trip != null)
                throw new DalApi.DO.TripException(ID, "There is no such trip.");
            return trip.Clone();
        }
        #endregion
        #region AdjacentStations
        public IEnumerable<AdjacentStations> GetALLAdjacentStations()
        {
            return from  AS in DataSource.ListAdjecentStations
                   select AS.Clone();
        }

        public AdjacentStations GetAdjacentStations(Station A, Station B)
        {
            DalApi.DO.AdjacentStations AS = DataSource.ListAdjecentStations.Find(As => As.Station1 == A.Code && As.Station2==B.Code );
            if (AS == null)
                throw new DalApi.DO.AdjacentStationsException(A.Code, B.Code, "The AdjacentStations didn't exits");
            return AS.Clone();
        }

        public void AddAdjacentStations(AdjacentStations adjacentStations)
        {
          if(DataSource.ListAdjecentStations.Find(As => As.Station1 == adjacentStations.Station1 && As.Station2 == adjacentStations.Station2) !=null)
            {
                throw new DalApi.DO.AdjacentStationsException(adjacentStations.Station1, adjacentStations.Station2, "Duplicate adjacentStations");
            }
            DataSource.ListAdjecentStations.Add(adjacentStations.Clone());
        }

        public void DeleteAdjacentStations(Station A, Station B)
        {
            AdjacentStations AS = DataSource.ListAdjecentStations.Find(a => a.Station1 == A.Code && a.Station2 == B.Code);
            if (AS != null) DataSource.ListAdjecentStations.Remove(AS);
            else throw new DalApi.DO.AdjacentStationsException(A.Code, B.Code, "The AdjacentStations didn't exits");
        }
        #endregion
        #region LineTrip
        public void AddLineTrip(DalApi.DO.LineTrip lineTrip)
        {
            if(DataSource.ListLineTrip.Find(LT=>LT.LindId==lineTrip.LindId && LT.StartAt==lineTrip.StartAt )!=null)
            {
                throw new DalApi.DO.LineTripException(lineTrip.LindId, lineTrip.StartAt, "duplicate LineTrip");
            }
            DataSource.ListLineTrip.Add(lineTrip.Clone());
        }
        public void DeleteLineTrip(int LineNum,TimeSpan startAT)
        {
            LineTrip LT = DataSource.ListLineTrip.Find(lt => lt.LindId.Equals(LineNum) && lt.StartAt.Equals(startAT));
            if (LT != null) DataSource.ListLineTrip.Remove(LT);
            else throw new DalApi.DO.LineTripException(LineNum, startAT, "The Line Trip does not exist in the system.");
        }
        public LineTrip GetLineTrip(int LineNum, TimeSpan startAT)
        {
            LineTrip LT = DataSource.ListLineTrip.Find(lt => lt.LindId.Equals(LineNum) && lt.StartAt.Equals(startAT));
            if (LT != null) return LT;
            else throw new DalApi.DO.LineTripException(LineNum, startAT, "The Line Trip does not exist in the system.");
        }
        public IEnumerable<LineTrip> GetsAllTripsForLine(int lineNum)
        {
            return from lineTrip in DataSource.ListLineTrip
                   where lineTrip.LindId.Equals(lineNum)
                   select lineTrip.Clone();
        }
        public void UpdateStartTime(int Id ,TimeSpan key,TimeSpan time)
        {
            if(GetLineTrip(Id,key) !=null)
            {
                DataSource.ListLineTrip.Find(LT => LT.LindId == Id && LT.StartAt == key).StartAt = time;
            }
            else throw new  DalApi.DO.LineTripException(Id, time, "duplicate LineTrip");
        }
        #endregion
        #region Line
       public void UpdateCode(int id, int newcode)
        {
            if (GetLine(id) != null)
            {
                DataSource.ListLines.Find(L => L.Id == id).Code = newcode; 
            }
            else throw new DalApi.DO.LineException(id, 0, "The line does not exist in the system.");
        }
        public void AddLine(DalApi.DO.Line line) 
        {
            line.Id = ++Line.RunningNum;
            if (DataSource.ListLines.Find(L => L.Id == line.Id) != null) 
                throw new DalApi.DO.LineException(line.Id, line.Code, "Duplicate Lines.");
            DataSource.ListLines.Add(line.Clone()); 
        }
        public void DeleteLine(int id)
        {
            DalApi.DO.Line line = DataSource.ListLines.Find(L => L.Id == id);
            if (line == null)
                throw new DalApi.DO.LineException(id, 0, "The line does not exist in the system.");
            DataSource.ListLines.Remove(line);
        }
        public Line GetLine(int id)
        {
            Line result = DataSource.ListLines.Find(L => L.Id == id );
            if (result == null) throw new DalApi.DO.LineException(id, 0, "The line does not exist in the system.");
            return result.Clone();
        }
        public IEnumerable<Line> GetAllLines()
        {
            return from line in DataSource.ListLines
                   select line.Clone();
        }
        #endregion
        #region LineStation

        public void AddLineStation(DalApi.DO.LineStation lineStation)
        {
            if (DataSource.ListLineStation.Find(LS => LS.LineId == lineStation.LineId && LS.Station == lineStation.Station) != null)
                throw new DalApi.DO.LineStationException(lineStation.LineId, lineStation.LineId, "Duplicate LineStation.");
            DataSource.ListLineStation.Add(lineStation.Clone());
        }
        public void DeleteLineStation(int LineNum,int StationNum)
        {
            LineStation Ls = DataSource.ListLineStation.Find(LS => LS.LineId == LineNum && LS.Station == StationNum);
            if (Ls != null) DataSource.ListLineStation.Remove(Ls);
            else throw new DalApi.DO.LineStationException(LineNum, StationNum, "Line station does not exist.");
        }
        public LineStation GetLineStation(int LineNum, int StationNum)
        {
            LineStation Ls = DataSource.ListLineStation.Find(LS => LS.LineId == LineNum && LS.Station == StationNum);
            if (Ls != null) return Ls.Clone();
            else throw new DalApi.DO.LineStationException(LineNum, StationNum, "Line station does not exist.");
        }
        public IEnumerable<LineStation> GetsAllStationInLine(int LineNum)
        {
            return from lineStation in DataSource.ListLineStation
                   where lineStation.LineId == LineNum
                   orderby lineStation.LineStationIndex
                   select lineStation.Clone();
        }
        public void Update(LineStation station,bool PlusOrMinus)
        {
            if(PlusOrMinus)
                station.LineStationIndex++;
            else station.LineStationIndex--;

        }
        #endregion
    }
}
