using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi.DO;

namespace DS
{
    public static class DataSource
    {
        public static List<Bus> ListBuses;
        public static List<BusOnTrip> ListBusOnTrips;
        public static List<BusStations> ListBusStations;
        public static List<Trip> ListTrip;
        public static List<Station> ListStations;
        public static List<User> UsersManager;
        public static List<LineStation> ListLineStation;
        public static List<LineTrip> ListLineTrip;
        public static List<AdjacentStations> ListAdjecentStations;
        static DataSource()
        {
            
        }
    }
}
