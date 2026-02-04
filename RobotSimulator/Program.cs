namespace RobotSimulator;

class Program
{
    static void Main(string[] args)
    {
        var simulator = new Services.RobotSimulator();
        RunInteractive(simulator);
    }

    private static void RunInteractive(Services.RobotSimulator simulator)
    {
        Console.WriteLine(" === Robot Simulator === ");
        Console.WriteLine("Commands: PLACE X,Y,F | MOVE | LEFT | RIGHT | REPORT | EXIT");
        Console.WriteLine("Example: PLACE 0,0,NORTH");
        Console.WriteLine();

        while (true)
        {
            Console.Write(" > ");
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                continue;

            var command = input.Trim().ToUpper();

            if (command == "EXIT" || command == "QUIT")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            var result = simulator.ExecuteCommand(command);
            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine(result);
            }
        }
    }
}