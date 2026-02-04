using RobotSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Models;

public class Robot
{
    public Position? Position { get; private set; }
    public Direction? Direction { get; private set; }
    public bool IsPlaced => Position != null && Direction != null;

    public void Place(Position position, Direction direction)
    {
        Position = position;
        Direction = direction;
    }

    public Position? GetNextPosition()
    {
        if (!IsPlaced || Position == null || Direction == null)
            return null;

        return Direction.Value switch
        {
            Models.Direction.NORTH => new Position(Position.X, Position.Y + 1),
            Models.Direction.SOUTH => new Position(Position.X, Position.Y - 1),
            Models.Direction.EAST => new Position(Position.X + 1, Position.Y),
            Models.Direction.WEST => new Position(Position.X - 1, Position.Y),
            _ => Position
        };
    }

    public void Move(Position newPosition)
    {
        Position = newPosition;
    }

    public void RotateLeft()
    {
        if (!IsPlaced || Direction == null)
            return;

        Direction = Direction.Value switch
        {
            Models.Direction.NORTH => Models.Direction.WEST,
            Models.Direction.WEST => Models.Direction.SOUTH,
            Models.Direction.SOUTH => Models.Direction.EAST,
            Models.Direction.EAST => Models.Direction.NORTH,
            _ => Direction.Value
        };
    }

    public void RotateRight()
    {
        if (!IsPlaced || Direction == null)
            return;

        Direction = Direction.Value switch
        {
            Models.Direction.NORTH => Models.Direction.EAST,
            Models.Direction.EAST => Models.Direction.SOUTH,
            Models.Direction.SOUTH => Models.Direction.WEST,
            Models.Direction.WEST => Models.Direction.NORTH,
            _ => Direction.Value
        };
    }

    public string Report()
    {
        if (!IsPlaced || Position == null || Direction == null)
            return string.Empty;

        return $"{ Position.X},{ Position.Y},{ Direction}";
    }
}
