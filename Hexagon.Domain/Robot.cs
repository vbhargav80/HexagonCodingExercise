using System;

namespace Hexagon.Domain
{
    public class Robot
    {
        private readonly int _xLowerBoundary;
        private readonly int _yLowerBoundary;
        private readonly int _xUpperBoundary;
        private readonly int _yUpperBoundary;

        public Position CurrentPosition { get; private set; }

        public Robot(TableDimensions tableDimensions)
        {
            _xLowerBoundary = 0;
            _yLowerBoundary = 0;
            _xUpperBoundary = tableDimensions.Length - 1;
            _yUpperBoundary = tableDimensions.Width - 1;
        }

        #region Public Methods

        public TurnResult TurnLeft()
        {
            if (CurrentPosition == null)
            {
                Console.WriteLine("Robot has not been placed on the table. Ignoring TurnLeft command...");
                return TurnResult.NotPlacedOnTable;
            }

            switch (CurrentPosition.Direction)
            {
                case Direction.North:
                    CurrentPosition.Direction = Direction.West;
                    break;
                case Direction.West:
                    CurrentPosition.Direction = Direction.South;
                    break;
                case Direction.South:
                    CurrentPosition.Direction = Direction.East;
                    break;
                case Direction.East:
                    CurrentPosition.Direction = Direction.North;
                    break;
            }

            return TurnResult.Successful;
        }

        public TurnResult TurnRight()
        {
            if (CurrentPosition == null)
            {
                Console.WriteLine("Robot has not been placed on the table. Ignoring TurnRight command...");
                return TurnResult.NotPlacedOnTable;
            }

            switch (CurrentPosition.Direction)
            {
                case Direction.North:
                    CurrentPosition.Direction = Direction.East;
                    break;
                case Direction.East:
                    CurrentPosition.Direction = Direction.South;
                    break;
                case Direction.South:
                    CurrentPosition.Direction = Direction.West;
                    break;
                case Direction.West:
                    CurrentPosition.Direction = Direction.North;
                    break;
            }

            return TurnResult.Successful;
        }

        public MoveResult Move()
        {
            if (CurrentPosition == null)
            {
                Console.WriteLine("Robot has not been placed on the table. Ignoring Move command...");
                return MoveResult.NotPlacedOnTable;
            }

            switch (CurrentPosition.Direction)
            {
                case Direction.North:
                    if (CurrentPosition.YCoordinate >= _yUpperBoundary)
                    {
                        Console.WriteLine("Cannot move beyond the table dimensions. Ignoring Move command...");
                        return MoveResult.OutOfBoundsOfTable;
                    }
                    else
                    {
                        CurrentPosition.YCoordinate++;
                    }
                    break;

                case Direction.West:
                    if (CurrentPosition.XCoordinate == _xLowerBoundary)
                    {
                        Console.WriteLine("Cannot move beyond the table dimensions. Ignoring Move command...");
                        return MoveResult.OutOfBoundsOfTable;
                    }
                    else
                    {
                        CurrentPosition.XCoordinate--;
                    }
                    break;

                case Direction.South:
                    if (CurrentPosition.YCoordinate == _yLowerBoundary)
                    {
                        Console.WriteLine("Cannot move beyond the table dimensions. Ignoring Move command...");
                        return MoveResult.OutOfBoundsOfTable;
                    }
                    else
                    {
                        CurrentPosition.YCoordinate--;
                    }
                    break;

                case Direction.East:
                    if (CurrentPosition.XCoordinate >= _xUpperBoundary)
                    {
                        Console.WriteLine("Cannot move beyond the table dimensions. Ignoring Move command...");
                        return MoveResult.OutOfBoundsOfTable;
                    }
                    else
                    {
                        CurrentPosition.XCoordinate++;
                    }
                    break;
            }

            return MoveResult.Successful;
        }

        public bool SetPosition(Position newPosition)
        {
            if (!IsValidPosition(newPosition))
            {
                Console.WriteLine("Invalid Position. Ignoring command...");
                return false;
            }

            CurrentPosition = newPosition;
            return true;
        }

        #endregion

        private bool IsValidPosition(Position position)
        {
            return position.XCoordinate >= _xLowerBoundary &&
                   position.XCoordinate <= _xUpperBoundary &&
                   position.YCoordinate >= _yLowerBoundary &&
                   position.YCoordinate <= _yUpperBoundary;
        }
    }
}

