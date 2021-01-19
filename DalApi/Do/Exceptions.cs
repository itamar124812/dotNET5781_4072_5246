using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi.DO
{
    #region Bus
    public class BadBusException:Exception
    {
       int LicenseNum;
       public   BadBusException(int licenseNum) : base() => LicenseNum = licenseNum;
       public  BadBusException(int licenseNum, string message) : base(message) => LicenseNum = licenseNum;
        public override string ToString()
        {
            string result = base.ToString();
            result += LicenseNum.ToString();
            return result;
        }
    }
    #endregion
    #region BusOnTrip
    public class BadBusOnTripException:Exception
    {
        int id;
        public BadBusOnTripException(int Id, string message) : base(message) => id = Id;
        public override string ToString()
        {
            string result = base.ToString();
            result += string.Format("BadBasOnTrip:{0}", id);
            return result;
        }
    }
    #endregion
#region User
    public class UserExceptions:Exception
    {
        string UserName;
        public UserExceptions(string userName, string message) : base(message) => UserName = userName;
        public override string ToString()
        {
            return base.ToString() + UserName;
        }
    }
    #endregion
    #region Station
    public class StationException:Exception
    {
       public  int Code;
       public  StationException(int code, string message) : base(message) => Code = code;
        public override string ToString()
        {
            return base.ToString() + string.Format("The bad code is: {0}", Code);
        }
    }
    #endregion
    #region Trip
    public class TripException:Exception
    {
        int id;
        public TripException(int Id, string message) : base(message) => id = Id;
        public override string ToString()
        {
            return base.ToString() + string.Format("The bad trip Id is: {0}", id);
        }
    }
    #endregion
    #region AdjacentStations
    public class AdjacentStationsException : Exception
    {
        int CodeStation1;
        int CodeStation2;
        public AdjacentStationsException(int codestation1, int codestation2, string message) : base(message) { CodeStation1 = codestation1; CodeStation2 =codestation2;}
        public override string ToString()
        {
            return base.ToString() + string.Format("Bad AdjacentStations station1 code: {0} station2 code:{1}.", CodeStation1, CodeStation2);
        }
    }
    #endregion
    #region Line
    public class LineException:Exception
    {
        public int Code;
        public  int Id;
        public LineException(int id,int code,string message):base(message) { Code = code;Id = id; }
        public override string ToString()
        {
            return base.ToString() + string.Format("Bad Line Id={0} Code={1}.", Id, Code);
        }
    }
    #endregion
    #region LineStation
    public class LineStationException:Exception
    {
        int LineNum;
        int StationNum;
        public LineStationException(int linenum,int stationnum,string message) : base(message) { LineNum = linenum;StationNum = stationnum; }
        public override string ToString()
        {
            return base.ToString() + String.Format("Bad Line Station in line number{0} station number{1}", LineNum, StationNum);
        }
    }
    #endregion
    #region LineTrip
    public class LineTripException:Exception
    {
        int LineNum;
        TimeSpan StartAt;
        public LineTripException(int busNum,TimeSpan startAt,string message) : base(message) { LineNum= busNum;StartAt = startAt; }
        public override string ToString()
        {
            return base.ToString() + string.Format("Bad Line Trip in Line Number:{0} who StartAt:{1}.",LineNum,StartAt);
        }
    }
    #endregion
    #region XMl
    public class XMLFileLoadCreateException : Exception
    {
        public string xmlFilePath;
        public XMLFileLoadCreateException(string xmlPath) : base() { xmlFilePath = xmlPath; }
        public XMLFileLoadCreateException(string xmlPath, string message) :
            base(message)
        { xmlFilePath = xmlPath; }
        public XMLFileLoadCreateException(string xmlPath, string message, Exception innerException) :
            base(message, innerException)
        { xmlFilePath = xmlPath; }

        public override string ToString() => base.ToString() + $", fail to load or create xml file: {xmlFilePath}";
    }
    #endregion
}
