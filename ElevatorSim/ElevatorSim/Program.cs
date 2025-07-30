using System.Net;
using ElevatorSim.Controllers;

namespace ElevatorSim;

class Program
{
    static void Main(string[] args)
    {


        Console.WriteLine("Enter The Number of Elevators: \n");

        var inputElevetors = Console.ReadLine();
        Console.WriteLine("Enter The Number Of Maximum Passangers: \n");
        var InputPassengers = Console.ReadLine();

        if (!int.TryParse(inputElevetors, out int elevetors) || !int.TryParse(inputElevetors, out int Passangers))
        {
            Console.WriteLine("Invalid number of elevators or passangers.");
            return;
        } // check if valuies are valid intergers

        var elevator = new ElevatorController(elevetors, Passangers);

        elevator.Proccess();
    }
}
