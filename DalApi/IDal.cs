﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi.DO;

namespace DalApi
{
    public interface IDal
    {
        #region user
        DO.User GetUser(string user);
        void AddUser(DO.User user);
        void DeleteUser(string user);
        #endregion
        #region Trip
        DO.Trip GetTrip(int ID);
        void AddTrip();
        #endregion
        #region Bus
        IEnumerable<DO.Bus> GetAllBuses();
        void AddBus(DO.Bus bus);
        DO.Bus GetBus(int LicenseNum);
        void DeleteBus(int LicenseNum);
        #endregion
        #region Station
        void AddStation(int code,string name,double Longitude, double Latitude);
        void DeleteStation(int code);
        DO.Station GetStation(int code);
        #endregion
        #region BusOnTrip
        void AddBusOnTrip(DO.BusOnTrip Trip );
        void DeleteBusOnTrip(int Id);
        DO.BusOnTrip GetBusOnTrip(int Id);
        #endregion

    }
}
