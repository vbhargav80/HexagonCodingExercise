using FluentAssertions;
using Xunit;

namespace Hexagon.Domain.Tests
{
    public class WhenRobotHasNotBeenPositionedOnTheTable : RobotTestBase
    {
        [Fact]
        public void ThenMoveCommandShouldReturnNotPlacedOnTable()
        {
            var moveResult = Robot.Move();
            moveResult.Should().Be(MoveResult.NotPlacedOnTable);
        }

        [Fact]
        public void ThenTurnLeftCommandShouldReturnNotPlacedOnTable()
        {
            var turnLeftResult = Robot.TurnLeft();
            turnLeftResult.Should().Be(TurnResult.NotPlacedOnTable);
        }

        [Fact]
        public void ThenTurnRightCommandShouldReturnNotPlacedOnTable()
        {
            var turnRightResult = Robot.TurnRight();
            turnRightResult.Should().Be(TurnResult.NotPlacedOnTable);
        }
    }
}
