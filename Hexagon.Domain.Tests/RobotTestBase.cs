namespace Hexagon.Domain.Tests
{
    public abstract class RobotTestBase
    {
        protected Robot Robot;

        protected RobotTestBase()
        {
            Robot = new Robot(new TableDimensions());
        }
    }
}
