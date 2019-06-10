using FluentAssertions;
using Xunit;

namespace Hexagon.Domain.Tests
{
    public class WhenRobotIsPositionedAtEastEdgeOfTableFacingEast : RobotTestBase
    {
        public WhenRobotIsPositionedAtEastEdgeOfTableFacingEast()
        {
            var tableDimensions = new TableDimensions();
            Robot.SetPosition(new Position
            {
                Direction = Direction.East,
                XCoordinate = tableDimensions.Length - 1,
                YCoordinate = 2
            });
        }

        [Fact]
        public void ThenMoveCommandShouldReturnOutOfBoundsResult()
        {
            var moveResult = Robot.Move();
            moveResult.Should().Be(MoveResult.OutOfBoundsOfTable);
        }

        [Fact]
        public void ThenTurnLeftCommandShouldSetPositionToNorth()
        {
            var turnResult = Robot.TurnLeft();
            turnResult.Should().Be(turnResult == TurnResult.Successful);
            Robot.CurrentPosition.Direction.Should().Be(Direction.North);
        }

        [Fact]
        public void ThenTurnRightCommandShouldSetPositionToSouth()
        {
            var turnResult = Robot.TurnRight();
            turnResult.Should().Be(turnResult == TurnResult.Successful);
            Robot.CurrentPosition.Direction.Should().Be(Direction.South);
        }
    }
}
