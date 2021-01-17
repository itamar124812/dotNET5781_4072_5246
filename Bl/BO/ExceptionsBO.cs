using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BO
{
    public class LineTripsException:Exception
    { 
        public LineTripsException(string message,Exception innerException) : base(message, innerException) { }
    }
    public class BadLineExceptions:Exception
    {
       public int Id;
        public int Code;
        public BadLineExceptions(string message,Exception innerException) :base(message,innerException) { Id = ((DalApi.DO.LineException)innerException).Id;Code=((DalApi.DO.LineException)innerException).Code; }
        public override string ToString()
        {
            return base.ToString() + string.Format("Bad line Id: {0} Code={1}.",Id,Code);
        }
    }
    public class BadStationException:Exception
    {
        public int Code;
        public BadStationException(string message, Exception innerException) : base(message, innerException) => Code = ((DalApi.DO.StationException)innerException).Code;
        public override string ToString()
        {
            return base.ToString() + string.Format("Bad StationCode: {0}",Code);
        }
    }
    public class UserException:Exception
    {
        public UserException(string message, Exception innerException) : base(message, innerException) { }
        public UserException(string message) : base(message) { }
        
    }
}
