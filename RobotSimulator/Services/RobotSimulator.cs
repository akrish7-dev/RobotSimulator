using RobotSimulator.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Services;

public class RobotSimulator
{
    private readonly Robot _robot;
    private readonly Table _table;
    private readonly CommandParser _commandParser;

    public RobotSimulator()
    {
        _robot = new Robot();
        _table = new Table();
        _commandParser = new CommandParser();
    }

    public string ExecuteCommand(string commandLine)
    {
        var command = _commandParser.Parse(commandLine);

        if (command == null)
            return string.Empty;

        return command.Type switch
        {
            CommandType.PLACE => ExecutePlace(command),
            CommandType.MOVE => ExecuteMove(),
            CommandType.LEFT => ExecuteLeft(),
            CommandType.RIGHT => ExecuteRight(),
            CommandType.REPORT => ExecuteReport(),
            _ => string.Empty
        };
    }

    private string ExecutePlace(Command command)
    {
        if (command.Position == null || command.Direction == null)
            return string.Empty;

        if (!_table.IsValidPosition(command.Position))
            return string.Empty;

        _robot.Place(command.Position, command.Direction.Value);
        return string.Empty;
    }

    private string ExecuteMove()
    {
        if (!_robot.IsPlaced)
            return string.Empty;

        var nextPosition = _robot.GetNextPosition();

        if (nextPosition != null && _table.IsValidPosition(nextPosition))
        {
            _robot.Move(nextPosition);
        }

        return string.Empty;
    }

    private string ExecuteLeft()
    {
        if (!_robot.IsPlaced)
            return string.Empty;

        _robot.RotateLeft();
        return string.Empty;
    }

    private string ExecuteRight()
    {
        if (!_robot.IsPlaced)
            return string.Empty;

        _robot.RotateRight();
        return string.Empty;
    }

    private string ExecuteReport()
    {
        if (!_robot.IsPlaced)
            return string.Empty;

        return _robot.Report();
    }

    public Robot GetRobot() => _robot;
}

