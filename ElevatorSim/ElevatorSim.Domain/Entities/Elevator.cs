
using ElevatorSim.Domain.Enums;

namespace ElevatorSim.Domain.Entities
{
    public class Elevator
    {

        public int Id { get; }
        public int CurrentFloor { get; private set; }

        public int PassengerCount { get; private set; } = 0;
        public Direction CurrentDirection { get; private set; } = Direction.Idle; //set elevator to stationary state
        public ElevetorType ElevetorType { get; set; } = ElevetorType.Passenger;
        public Queue<int> Targets { get; } = new(); // we elevator is supposed to stop
        public int MaxPassengers { get; }

        public bool IsMoving => Targets.Count > 0;


        public Elevator(int id, int currentFloor, int maxPassengers)
        {
            Id = id;
            CurrentFloor = currentFloor;
            MaxPassengers = maxPassengers;
        }


        public void AddPassagers(int count)
        {
            PassengerCount += count;
        }

        //adding targeted floors

        public void AddTarget(int floor)
        {
            if (!Targets.Contains(floor))  // add only if floor is not in the queue
                Targets.Enqueue(floor);

        }


        public bool TakePassangers(int awaitintPassengers)
        {
            return PassengerCount + awaitintPassengers <= MaxPassengers;
        }

        public void RemoveAllPassengers()
        {
            PassengerCount = 0;
        }

        // tracking movement
        public void Elevate(ElevetorType elevetorType)
        {

            switch (elevetorType)
            {
                case ElevetorType.Passenger:
                    PassangerElevator();
                    break;
                default:
                    break;

            }
        }


        public void PassangerElevator()
        {
            if (Targets.Count == 0)
            {
                CurrentDirection = Direction.Idle;
                return;
            }

            var target = Targets.Peek(); // get floor in front

            if (CurrentFloor < target)
            {
                CurrentFloor++;   // move elevator up

                CurrentDirection = Direction.Up;
            }

            else if (CurrentFloor > target)
            {
                CurrentFloor--;
                CurrentDirection = Direction.Down;
            }
            else
            {
                Targets.Dequeue(); // destination reached
                RemoveAllPassengers(); //
                CurrentDirection = Direction.Idle;
            }

        }

        public string ElevatorStatus()
        {
            var isMoving = IsMoving ? "Yes" : "No";
            return $"Elevator {Id}: Floor {CurrentFloor}, Direction: {CurrentDirection}, " +
            $"Moving: {isMoving}, Passengers: {PassengerCount}/{MaxPassengers}, Targets: [{string.Join(",", Targets)}]";
        }

    }
}
