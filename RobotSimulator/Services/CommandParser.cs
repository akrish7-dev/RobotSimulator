using RobotSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Services;

public class CommandParser
{
    public Command? Parse(string commandLine)
    {
        if (string.IsNullOrWhiteSpace(commandLine))
            return null;

        var parts = commandLine.Trim().ToUpper().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 0)
            return null;

        var commandType = parts[0];

        return commandType switch
        {
            "PLACE" => ParsePlace(parts),
            "MOVE" => new Command { Type = CommandType.MOVE },
            "LEFT" => new Command { Type = CommandType.LEFT },
            "RIGHT" => new Command { Type = CommandType.RIGHT },
            "REPORT" => new Command { Type = CommandType.REPORT },
            _ => null
        };
    }

    private Command? ParsePlace(string[] parts)
    {
        if (parts.Length < 2)
            return null;

        var parameters = parts[1].Split(',');

        if (parameters.Length != 3)
            return null;

        if (!int.TryParse(parameters[0], out int x))
            return null;

        if (!int.TryParse(parameters[1], out int y))
            return null;

        if (!Enum.TryParse<Direction>(parameters[2], true, out Direction direction))
            return null;

        return new Command
        {
            Type = CommandType.PLACE,
            Position = new Position(x, y),
            Direction = direction
        };
    }
}
