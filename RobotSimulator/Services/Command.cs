using RobotSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Services;

public enum CommandType
{
    PLACE,
    MOVE,
    LEFT,
    RIGHT,
    REPORT
}

public class Command
{
    public CommandType Type { get; set; }
    public Position? Position { get; set; }
    public Direction? Direction { get; set; }
}