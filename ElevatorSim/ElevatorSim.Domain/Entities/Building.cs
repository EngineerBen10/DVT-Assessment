using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevatorSim.Domain.Entities
{
    public class Building
    {
        public int Floor { get; }

        public int PassengerCount { get; }

        public Building(int floor, int passengerCount)
        {
            Floor = floor;
            PassengerCount = passengerCount;
        }
    }
}