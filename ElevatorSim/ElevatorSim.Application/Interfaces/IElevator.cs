using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevatorSim.Domain.Entities;

namespace ElevatorSim.Application.Interfaces
{
    public interface IElevator
    {
        void Move();
        void ElevatorStatus();

        void GetElevatorSpaceAvailebility(Building building);
        
    }
}