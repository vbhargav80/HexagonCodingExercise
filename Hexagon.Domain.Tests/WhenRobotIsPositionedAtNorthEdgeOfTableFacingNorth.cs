using FluentAssertions;
using Xunit;

namespace Hexagon.Domain.Tests
{
    public class WhenRobotIsPositionedAtNorthEdgeOfTableFacingNorth : RobotTestBase
    {
        public WhenRobotIsPositionedAtNorthEdgeOfTableFacingNorth()
        {
            var tableDimensions = new TableDimensions();
            Robot.SetPosition(new Position
            {
                Direction = Direction.North,
                XCoordinate = tableDimensions.Length - 1,
                YCoordinate = tableDimensions.Width - 1
            });
        }

        [Fact]
        public void ThenMoveCommandShouldReturnOutOfBoundsResult()
        {
            var moveResult = Robot.Move();
            moveResult.Should().Be(MoveResult.OutOfBoundsOfTable);
        }

        [Fact]
        public void ThenTurnLeftCommandShouldSetPositionToWest()
        {
            var turnResult = Robot.TurnLeft();
            turnResult.Should().Be(turnResult == TurnResult.Successful);
            Robot.CurrentPosition.Direction.Should().Be(Direction.West);
        }

        [Fact]
        public void ThenTurnRightCommandShouldSetPositionToWest()
        {
            var turnResult = Robot.TurnRight();
            turnResult.Should().Be(turnResult == TurnResult.Successful);
            Robot.CurrentPosition.Direction.Should().Be(Direction.East);
        }

        [Fact]
        public void ThenTurnRightAndMoveShouldReturnOutOfBoundsResult()
        {
            var turnResult = Robot.TurnRight();
            var moveResult = Robot.Move();
            moveResult.Should().Be(MoveResult.OutOfBoundsOfTable);
            turnResult.Should().Be(TurnResult.Successful);
        }

        [Fact]
        public void ThenTurnLeftAndMoveShouldSetCorrectPosition()
        {
            var turnResult = Robot.TurnLeft();
            var moveResult = Robot.Move();
            moveResult.Should().Be(MoveResult.Successful);
            turnResult.Should().Be(TurnResult.Successful);
            Robot.CurrentPosition.XCoordinate.Should().Be(3);
        }

        [Fact]
        public void ThenTurnLeftTwiceAndMoveShouldSetCorrectPosition()
        {
            Robot.TurnRight();
            Robot.TurnRight();
            var moveResult = Robot.Move();
            moveResult.Should().Be(MoveResult.Successful);
            Robot.CurrentPosition.YCoordinate.Should().Be(3);
        }
    }
}
