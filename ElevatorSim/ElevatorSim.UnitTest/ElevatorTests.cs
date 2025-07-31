using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevatorSim.Domain.Entities;
using Xunit;

namespace ElevatorSim.UnitTest
{
    public class ElevatorTests
    {
        [Fact]
        public void AddPassanger_Test()
        {
            var elevator = new Elevator(id: 1, currentFloor: 0, maxPassengers: 15);

            elevator.AddPassagers(10);

            Assert.Equal(10, elevator.PassengerCount);

        }

        [Fact]

        public void AddTarget_Test()
        {
            var elevator = new Elevator(id: 1, currentFloor: 3, maxPassengers: 4);

            elevator.AddTarget(4);

            Assert.Contains(4, elevator.Targets);

            elevator.AddTarget(4);
            Assert.Contains(4, elevator.Targets);
        }

        [Fact]
        public void TakePassangerCount_Test()
        {

            var elevator = new Elevator(id: 1, currentFloor: 0, maxPassengers: 15);

            elevator.AddPassagers(10);

            var canTake = elevator.TakePassangers(5);
            Assert.True(canTake);
            
        }
    }
}