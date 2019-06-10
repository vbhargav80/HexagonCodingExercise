using FluentAssertions;
using Xunit;

namespace Hexagon.Domain.Tests
{
    public class WhenRobotIsPositionedAtSouthEdgeOfTableFacingSouth : RobotTestBase
    {
        public WhenRobotIsPositionedAtSouthEdgeOfTableFacingSouth()
        {
            Robot.SetPosition(new Position
            {
                Direction = Direction.South,
                XCoordinate = 0,
                YCoordinate = 0
            });
        }

        [Fact]
        public void ThenMoveCommandShouldReturnOutOfBoundsResult()
        {
            var moveResult = Robot.Move();
            moveResult.Should().Be(MoveResult.OutOfBoundsOfTable);
        }

        [Fact]
        public void ThenTurnLeftCommandShouldSetPositionToEast()
        {
            var turnResult = Robot.TurnLeft();
            turnResult.Should().Be(turnResult == TurnResult.Successful);
            Robot.CurrentPosition.Direction.Should().Be(Direction.East);
        }

        [Fact]
        public void ThenTurnRightCommandShouldSetPositionToWest()
        {
            var turnResult = Robot.TurnRight();
            turnResult.Should().Be(turnResult == TurnResult.Successful);
            Robot.CurrentPosition.Direction.Should().Be(Direction.West);
        }
    }
}
