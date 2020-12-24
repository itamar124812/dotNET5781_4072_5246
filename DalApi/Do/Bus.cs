using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    enum BusStatus {ReadyForTrip, OnTrip,Refueling, Treatment }
    class Bus
    {
        int LicenseNum { get; set; }
        DateTime FromDate { get; set; }
        double TotalTrip { get; set; }
        double FuelRemain { get; set; }
        BusStatus Status { get; set; }

    }
}
