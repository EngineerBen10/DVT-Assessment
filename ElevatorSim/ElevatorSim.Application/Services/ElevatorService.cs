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

        public void GetElevatorSpaceAvailebility(Building building)
        {
            //check space availability on the elevators to take passengers

            var passengers = _elevators
            .Where(e => e.TakePassangers(building.PassengerCount))
            .OrderBy(e => Math.Abs(e.CurrentFloor - building.Floor)) // checking the closet elevator to take you
            .ThenBy(e => e.IsMoving ? 1 : 0)
            .ToList();

            if (!passengers.Any())
            {
                Console.WriteLine("Sorry all elevators are in full capacity.");
                return;
            } 
        }

        public void Move() // elevator movement
        {
            foreach (var elevator in _elevators)
                elevator.Elevate();
        }
    }
}