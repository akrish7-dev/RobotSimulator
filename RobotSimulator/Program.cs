using static System.Runtime.InteropServices.JavaScript.JSType;

using RobotSimulator.Services;

namespace RobotSimulator;

class Program
{
    static void Main(string[] args)
    {
        var simulator = new Services.RobotSimulator();

        if (args.Length > 0)
        {
            // File input mode
            RunFromFile(simulator, args[0]);
        }
        else
        {
            // Interactive mode
            RunInteractive(simulator);
        }
    }

    private static void RunFromFile(Services.RobotSimulator simulator, string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: File '{filePath}' not found.");
                return;
            }

            var commands = File.ReadAllLines(filePath);
            Console.WriteLine($"Reading commands from: { filePath}");
            Console.WriteLine();

            foreach (var command in commands)
            {
                if (string.IsNullOrWhiteSpace(command))
                    continue;

                Console.WriteLine($" > { command}");
                var result = simulator.ExecuteCommand(command.Trim());
                if (!string.IsNullOrEmpty(result))
                {
                    Console.WriteLine(result);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: { ex.Message}");
        }
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