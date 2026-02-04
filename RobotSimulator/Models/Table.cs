using RobotSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Models;

public class Table
{
    public int Width { get; }
    public int Height { get; }

    public Table(int width = 5, int height = 5)
    {
        Width = width;
        Height = height;
    }

    public bool IsValidPosition(Position position)
    {
        return position.X >= 0 && position.X < Width &&
               position.Y >= 0 && position.Y < Height;
    }
}