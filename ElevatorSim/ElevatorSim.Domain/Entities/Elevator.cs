namespace Elevator.Domain.Entities
{
    public class Elevator
    {

        public int Id { get; }
        public int CurrentFloor { get; private set; }

        publis PassengerCount { get; private set; } = 0;
        public Direction CurrentDirection { get; private set; } = Direction.Idle; //set elevator to stationary state

        public Queue<int> Targets { get; } = new(); // we elevator is supposed to stop
        public int MaxPassengers { get; }

        public bool IsMoving => Targets.Count > 0;


        public Elevator(int id, int currentFloor, int maxPassengers)
        {
            Id = id;
            CurrentFlor = currentFloor;
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



        // tracking movement
        public void Elevate()
        {

            if (Targets.Count == 0)
            {
                CurrentDirection  = Direction.Idle;
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
                CurrentDirection = Direction.Idle;
            }

        }


        public string ElevatorStatus()
        {
            return $"Elevator {Id}: Floor {CurrentFloor}, Dir: {CurrentDirection}, " +
        $"Moving: {IsMoving}, Passengers: {PassengerCount}/{MaxPassengers}, Targets: [{string.Join(",", Targets)}]";
        }

    }
}
