using FluentAssertions;
using Xunit;

namespace Hexagon.Domain.Tests
{
    public class WhenRobotIsPositionedAtWestEdgeOfTableFacingWest : RobotTestBase
    {
        public WhenRobotIsPositionedAtWestEdgeOfTableFacingWest()
        {
            Robot.SetPosition(new Position
            {
                Direction = Direction.West,
                XCoordinate = 0,
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
        public void ThenTurnRightAndMoveShouldSetCorrectPosition()
        {
            var turnResult = Robot.TurnRight();
            var moveResult = Robot.Move();
            moveResult.Should().Be(MoveResult.Successful);
            turnResult.Should().Be(TurnResult.Successful);
            Robot.CurrentPosition.YCoordinate.Should().Be(3);
        }

        [Fact]
        public void ThenTurnLeftAndMoveShouldSetCorrectPosition()
        {
            var turnResult = Robot.TurnLeft();
            var moveResult = Robot.Move();
            moveResult.Should().Be(MoveResult.Successful);
            turnResult.Should().Be(TurnResult.Successful);
            Robot.CurrentPosition.YCoordinate.Should().Be(1);
        }

        [Fact]
        public void ThenTurnLeftCommandShouldSetPositionToSouth()
        {
            var turnResult = Robot.TurnLeft();
            turnResult.Should().Be(turnResult == TurnResult.Successful);
            Robot.CurrentPosition.Direction.Should().Be(Direction.South);
        }

        [Fact]
        public void ThenTurnRightCommandShouldSetPositionToNorth()
        {
            var turnResult = Robot.TurnRight();
            turnResult.Should().Be(turnResult == TurnResult.Successful);
            Robot.CurrentPosition.Direction.Should().Be(Direction.North);
        }
    }
}
