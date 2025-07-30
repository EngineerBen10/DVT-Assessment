using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ElevatorSim.Application.Services;
using ElevatorSim.Domain.Entities;


namespace ElevatorSim.Controllers
{

    public class ElevatorController
    {
        private readonly ElevatorService _elevatorService;

        public ElevatorController(int numberOfElevators, int maxPassengers)
        {
            _elevatorService = new ElevatorService(numberOfElevators, maxPassengers);
        }



        public async Task Proccess()
        {

            while (true)
            {
                _elevatorService.ElevatorStatus();

                 Console.WriteLine("\n");

                Console.WriteLine("Enter The Floor Number: \n");

                var inputFoor = Console.ReadLine();
                Console.WriteLine("Enter The Number Of  Passangers: \n");
                var InputPassengers = Console.ReadLine();

                if (!int.TryParse(inputFoor, out int floor) || !int.TryParse(InputPassengers, out int passangers))
                {
                    Console.WriteLine("Invalid floor  or passanger number.");

                    break;
                } // check if values are valid intergers

                _elevatorService.GetElevatorSpaceAvailebility(new Building(floor, passangers));

                _elevatorService.Move();

                await Task.Delay(1000); // pausing current method for a second(1 second) until task is complete


            }
        }
    }
}