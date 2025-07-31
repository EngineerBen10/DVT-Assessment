using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevatorSim.Domain.Entities;
using ElevatorSim.Domain.Enums;
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

        [Fact]

        public void Elevator_Elevate_Test()
        {
            var elevator = new Elevator(id: 1, currentFloor: 3, maxPassengers: 5);

            elevator.AddPassagers(5);
            elevator.AddTarget(1);

            Assert.Equal(elevator.PassengerCount, elevator.MaxPassengers);
            elevator.Elevate(ElevetorType.Passenger);
            Assert.Equal(2, elevator.CurrentFloor);
            Assert.Equal(Direction.Down, elevator.CurrentDirection);

        }
    }
}