using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ElevatorSim.Application.Services;


namespace ElevatorSim.Controllers
{

    public class ElevatorController
    {
        private readonly ElevatorService _elevatorService;

        public ElevatorController(int numberOfElevators, int maxPassengers)
        {
            _elevatorService = new ElevatorService(numberOfElevators, maxPassengers);
        }



        public  Task Proccess()
        {

            while (true)
            {
                _elevatorService.ElevatorStatus();

                
            }
        }
    }
}