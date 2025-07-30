using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevatorSim.Application.Interfaces;
using ElevatorSim.Domain.Entities;
namespace ElevatorSim.Application.Services
{
    public class ElevatorService : IElevator
    {

         private readonly List<Elevator> _elevators;
        public ElevatorService(int numberOfElevators, int maxPassengers)
        {
            _elevators = Enumerable.Range(1, numberOfElevators)
            .Select(id => new Elevator(id,0,maxPassengers))
            .ToList();
        }

        public void ElevatorStatus()
        {
            foreach (var elevator in _elevators)
                Console.WriteLine(elevator.ElevatorStatus());
        }

        public void Move() // elevator movement
        {
            foreach (var elevator in _elevators)
                elevator.Elevate();
        }
    }
}